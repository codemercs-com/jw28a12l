using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WriteLed
{
    public partial class Form1 : Form
    {
        #region WinAPI

        [DllImport("setupapi.dll")]
        static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, IntPtr Enumerator, IntPtr hwndParent, int Flags);

        [DllImport("setupapi.dll")]
        static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, int memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        [DllImport(@"setupapi.dll")]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

        [DllImport(@"setupapi.dll")]
        static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

        [DllImport(@"kernel32.dll")]
        static extern IntPtr CreateFile(string fileName, uint fileAccess, uint fileShare, FileMapProtection securityAttributes, uint creationDisposition, uint flags, IntPtr overlapped);

        [DllImport("kernel32.dll")]
        static extern bool WriteFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToWrite, ref uint lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll")]
        static extern bool ReadFile(IntPtr hFile, [Out] byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("hid.dll")]
        static extern void HidD_GetHidGuid(ref Guid Guid);

        [DllImport("hid.dll")]
        static extern bool HidD_GetPreparsedData(IntPtr HidDeviceObject, ref IntPtr PreparsedData);

        [DllImport("hid.dll")]
        static extern bool HidD_GetAttributes(IntPtr DeviceObject, ref HIDD_ATTRIBUTES Attributes);

        [DllImport("hid.dll")]
        static extern uint HidP_GetCaps(IntPtr PreparsedData, ref HIDP_CAPS Capabilities);

        [DllImport("hid.dll")]
        static extern int HidP_GetButtonCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_BUTTON_CAPS[] ButtonCaps, ref ushort ButtonCapsLength, IntPtr PreparsedData);

        [DllImport("hid.dll")]
        static extern int HidP_GetValueCaps(HIDP_REPORT_TYPE ReportType, [In, Out] HIDP_VALUE_CAPS[] ValueCaps, ref ushort ValueCapsLength, IntPtr PreparsedData);

        [DllImport("hid.dll")]
        static extern int HidP_MaxUsageListLength(HIDP_REPORT_TYPE ReportType, ushort UsagePage, IntPtr PreparsedData);

        [DllImport("hid.dll")]
        static extern int HidP_SetUsages(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, short Usages, ref int UsageLength, IntPtr PreparsedData, IntPtr HID_Report, int ReportLength);

        [DllImport("hid.dll")]
        static extern int HidP_SetUsageValue(HIDP_REPORT_TYPE ReportType, ushort UsagePage, short LinkCollection, ushort Usage, ulong UsageValue, IntPtr PreparsedData, IntPtr HID_Report, int ReportLength);

        [DllImport("setupapi.dll")]
        static extern bool SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("hid.dll")]
        static extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

        [DllImport("hid.dll")]
        private static extern bool HidD_GetProductString(IntPtr HidDeviceObject, IntPtr Buffer, uint BufferLength);

        [DllImport("hid.dll")]
        static extern bool HidD_GetSerialNumberString(IntPtr HidDeviceObject, IntPtr Buffer, Int32 BufferLength);

        [DllImport("hid.dll")]
        static extern Boolean HidD_GetManufacturerString(IntPtr HidDeviceObject, IntPtr Buffer, Int32 BufferLength);

        [DllImport("kernel32.dll")]
        static extern uint GetLastError();

        #endregion

        #region DLL Var

        IntPtr hardwareDeviceInfo;

        const int DIGCF_DEFAULT = 0x00000001;
        const int DIGCF_PRESENT = 0x00000002;
        const int DIGCF_ALLCLASSES = 0x00000004;
        const int DIGCF_PROFILE = 0x00000008;
        const int DIGCF_DEVICEINTERFACE = 0x00000010;

        const uint GENERIC_READ = 0x80000000;
        const uint GENERIC_WRITE = 0x40000000;
        const uint GENERIC_EXECUTE = 0x20000000;
        const uint GENERIC_ALL = 0x10000000;

        const uint FILE_SHARE_READ = 0x00000001;
        const uint FILE_SHARE_WRITE = 0x00000002;
        const uint FILE_SHARE_DELETE = 0x00000004;

        const uint CREATE_NEW = 1;
        const uint CREATE_ALWAYS = 2;
        const uint OPEN_EXISTING = 3;
        const uint OPEN_ALWAYS = 4;
        const uint TRUNCATE_EXISTING = 5;

        const int HIDP_STATUS_SUCCESS = 1114112;
        const int DEVICE_PATH = 260;
        const int INVALID_HANDLE_VALUE = -1;

        enum FileMapProtection : uint
        {
            PageReadonly = 0x02,
            PageReadWrite = 0x04,
            PageWriteCopy = 0x08,
            PageExecuteRead = 0x20,
            PageExecuteReadWrite = 0x40,
            SectionCommit = 0x8000000,
            SectionImage = 0x1000000,
            SectionNoCache = 0x10000000,
            SectionReserve = 0x4000000,
        }

        enum HIDP_REPORT_TYPE : ushort
        {
            HidP_Input = 0x00,
            HidP_Output = 0x01,
            HidP_Feature = 0x02,
        }

        [StructLayout(LayoutKind.Sequential)]
        struct LIST_ENTRY
        {
            public IntPtr Flink;
            public IntPtr Blink;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct DEVICE_LIST_NODE
        {
            public LIST_ENTRY Hdr;
            public IntPtr NotificationHandle;
            public HID_DEVICE HidDeviceInfo;
            public bool DeviceOpened;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVICE_INTERFACE_DATA
        {
            public Int32 cbSize;
            public Guid interfaceClassGuid;
            public Int32 flags;
            private UIntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public int cbSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
            public string DevicePath;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVINFO_DATA
        {
            public int cbSize;
            public Guid classGuid;
            public UInt32 devInst;
            public IntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HIDP_CAPS
        {
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 Usage;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 UsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 InputReportByteLength;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 OutputReportByteLength;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 FeatureReportByteLength;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
            public UInt16[] Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberLinkCollectionNodes;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberInputDataIndices;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberOutputDataIndices;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureButtonCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureValueCaps;
            [MarshalAs(UnmanagedType.U2)]
            public UInt16 NumberFeatureDataIndices;
        };

        [StructLayout(LayoutKind.Sequential)]
        struct HIDD_ATTRIBUTES
        {
            public Int32 Size;
            public UInt16 VendorID;
            public UInt16 ProductID;
            public Int16 VersionNumber;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct ButtonData
        {
            public Int32 UsageMin;
            public Int32 UsageMax;
            public Int32 MaxUsageLength;
            public Int16 Usages;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct ValueData
        {
            public ushort Usage;
            public ushort Reserved;

            public ulong Value;
            public long ScaledValue;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct HID_DATA
        {
            [FieldOffset(0)]
            public bool IsButtonData;
            [FieldOffset(1)]
            public byte Reserved;
            [FieldOffset(2)]
            public ushort UsagePage;
            [FieldOffset(4)]
            public Int32 Status;
            [FieldOffset(8)]
            public Int32 ReportID;
            [FieldOffset(16)]
            public bool IsDataSet;

            [FieldOffset(17)]
            public ButtonData ButtonData;
            [FieldOffset(17)]
            public ValueData ValueData;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HIDP_Range
        {
            public ushort UsageMin, UsageMax;
            public ushort StringMin, StringMax;
            public ushort DesignatorMin, DesignatorMax;
            public ushort DataIndexMin, DataIndexMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct HIDP_NotRange
        {
            public ushort Usage, Reserved1;
            public ushort StringIndex, Reserved2;
            public ushort DesignatorIndex, Reserved3;
            public ushort DataIndex, Reserved4;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct HIDP_BUTTON_CAPS
        {
            [FieldOffset(0)]
            public ushort UsagePage;
            [FieldOffset(2)]
            public byte ReportID;
            [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
            public bool IsAlias;
            [FieldOffset(4)]
            public short BitField;
            [FieldOffset(6)]
            public short LinkCollection;
            [FieldOffset(8)]
            public short LinkUsage;
            [FieldOffset(10)]
            public short LinkUsagePage;
            [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
            public bool IsRange;
            [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
            public bool IsStringRange;
            [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
            public bool IsDesignatorRange;
            [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
            public bool IsAbsolute;
            [FieldOffset(16), MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
            public int[] Reserved;
            [FieldOffset(56)]
            public HIDP_Range Range;
            [FieldOffset(56)]
            public HIDP_NotRange NotRange;
        }

        [StructLayout(LayoutKind.Explicit)]
        struct HIDP_VALUE_CAPS
        {
            [FieldOffset(0)]
            public ushort UsagePage;
            [FieldOffset(2)]
            public byte ReportID;
            [FieldOffset(3), MarshalAs(UnmanagedType.U1)]
            public bool IsAlias;
            [FieldOffset(4)]
            public ushort BitField;
            [FieldOffset(6)]
            public ushort LinkCollection;
            [FieldOffset(8)]
            public ushort LinkUsage;
            [FieldOffset(10)]
            public ushort LinkUsagePage;
            [FieldOffset(12), MarshalAs(UnmanagedType.U1)]
            public bool IsRange;
            [FieldOffset(13), MarshalAs(UnmanagedType.U1)]
            public bool IsStringRange;
            [FieldOffset(14), MarshalAs(UnmanagedType.U1)]
            public bool IsDesignatorRange;
            [FieldOffset(15), MarshalAs(UnmanagedType.U1)]
            public bool IsAbsolute;
            [FieldOffset(16), MarshalAs(UnmanagedType.U1)]
            public bool HasNull;
            [FieldOffset(17)]
            public byte Reserved;
            [FieldOffset(18)]
            public short BitSize;
            [FieldOffset(20)]
            public short ReportCount;
            [FieldOffset(22)]
            public ushort Reserved2a;
            [FieldOffset(24)]
            public ushort Reserved2b;
            [FieldOffset(26)]
            public ushort Reserved2c;
            [FieldOffset(28)]
            public ushort Reserved2d;
            [FieldOffset(30)]
            public ushort Reserved2e;
            [FieldOffset(32)]
            public int UnitsExp;
            [FieldOffset(36)]
            public int Units;
            [FieldOffset(40)]
            public int LogicalMin;
            [FieldOffset(44)]
            public int LogicalMax;
            [FieldOffset(48)]
            public int PhysicalMin;
            [FieldOffset(52)]
            public int PhysicalMax;
            [FieldOffset(56)]
            public HIDP_Range Range;
            [FieldOffset(56)]
            public HIDP_NotRange NotRange;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct HID_DEVICE
        {
            public String Manufacturer;
            public String Product;
            public Int32 SerialNumber;
            public UInt16 VersionNumber;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DEVICE_PATH)]
            public String DevicePath;
            public IntPtr Pointer;

            public Boolean OpenedForRead;
            public Boolean OpenedForWrite;
            public Boolean OpenedOverlapped;
            public Boolean OpenedExclusive;

            public IntPtr Ppd;
            public HIDP_CAPS Caps;
            public HIDD_ATTRIBUTES Attributes;

            public IntPtr[] InputReportBuffer;
            public HID_DATA[] InputData;
            public Int32 InputDataLength;
            public HIDP_BUTTON_CAPS[] InputButtonCaps;
            public HIDP_VALUE_CAPS[] InputValueCaps;

            public IntPtr[] OutputReportBuffer;
            public HID_DATA[] OutputData;
            public Int32 OutputDataLength;
            public HIDP_BUTTON_CAPS[] OutputButtonCaps;
            public HIDP_VALUE_CAPS[] OutputValueCaps;

            public IntPtr[] FeatureReportBuffer;
            public HID_DATA[] FeatureData;
            public Int32 FeatureDataLength;
            public HIDP_BUTTON_CAPS[] FeatureButtonCaps;
            public HIDP_VALUE_CAPS[] FeatureValueCaps;
        }

        #endregion

        struct JW28A12LData
        {
            public UInt16 axis0;
            public UInt16 axis1;
            public UInt16 axis2;
            public UInt16 axis3;
            public byte buttons;
            public UInt16 matrix;

        }

        //Some defines for JW28A12L
        public const uint VENDOR_ID = 0x07c0;
        public const uint PID_JW28A12L = 0x1181;
        public const uint JW28A12L_REPORT_SIZE_OUT = 5; //Report ID + 4 data bytes
        public const uint JW28A12L_REPORT_SIZE_IN = 11; //Report ID + 10 data bytes

        //JW28A12L output options
        public const byte OUTPUT_IDLE = 0x00;
        public const byte OUTPUT_STATIC_ON = 0x01;
        public const byte OUTPUT_FAST = 0x02;
        public const byte OUTPUT_HEARTBEAT = 0x03;

        //global
        HID_DEVICE m_Device = new HID_DEVICE();

        public Form1()
        {
            InitializeComponent();
            
            cmbOut0.SelectedIndex = 0;
            cmbOut1.SelectedIndex = 0;
            cmbOut2.SelectedIndex = 0;
            cmbOut3.SelectedIndex = 0;
        }

        //Search for USB HID devices and returns count of devices
        Int32 FindDeviceNumber()
        {
            Guid hidGuid = new Guid();
            SP_DEVICE_INTERFACE_DATA deviceInfoData = new SP_DEVICE_INTERFACE_DATA();

            HidD_GetHidGuid(ref hidGuid);

            // Open a handle to the plug and play dev node.
            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
            hardwareDeviceInfo = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));

            int Index = 0;
            while (SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, IntPtr.Zero, ref hidGuid, Index, ref deviceInfoData))
            {
                Index++;
            }

            GC.Collect();

            return (Index);
        }
       
        //Open HID device and create HANDLE and other stuff
        void OpenDevice(String DevicePath, ref HID_DEVICE[] HID_Device, Int32 iHIDD)
        {
            HID_Device[iHIDD].DevicePath = DevicePath;

            CloseHandle(HID_Device[iHIDD].Pointer);
            HID_Device[iHIDD].Pointer = CreateFile(HID_Device[iHIDD].DevicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, IntPtr.Zero);
            HID_Device[iHIDD].Caps = new HIDP_CAPS();
            HID_Device[iHIDD].Attributes = new HIDD_ATTRIBUTES();

            HidD_FreePreparsedData(ref HID_Device[iHIDD].Ppd);
            HID_Device[iHIDD].Ppd = IntPtr.Zero;

            HidD_GetPreparsedData(HID_Device[iHIDD].Pointer, ref HID_Device[iHIDD].Ppd);
            HidD_GetAttributes(HID_Device[iHIDD].Pointer, ref HID_Device[iHIDD].Attributes);
            HidP_GetCaps(HID_Device[iHIDD].Ppd, ref HID_Device[iHIDD].Caps);

            IntPtr Buffer = Marshal.AllocHGlobal(256);
            {
                if (HidD_GetManufacturerString(HID_Device[iHIDD].Pointer, Buffer, 256))
                    HID_Device[iHIDD].Manufacturer = Marshal.PtrToStringAuto(Buffer);

                if (HidD_GetProductString(HID_Device[iHIDD].Pointer, Buffer, 256))
                    HID_Device[iHIDD].Product = Marshal.PtrToStringAuto(Buffer);

                if (HidD_GetSerialNumberString(HID_Device[iHIDD].Pointer, Buffer, 256))
                    Int32.TryParse(Marshal.PtrToStringAuto(Buffer), out HID_Device[iHIDD].SerialNumber);
            }

            Marshal.FreeHGlobal(Buffer);
            GC.Collect();
        }

        Int32 FindKnownDevices(ref HID_DEVICE[] HID_Devices)
        {
            Guid hidGuid = new Guid();
            SP_DEVICE_INTERFACE_DATA deviceInfoData = new SP_DEVICE_INTERFACE_DATA();
            SP_DEVICE_INTERFACE_DETAIL_DATA functionClassDeviceData = new SP_DEVICE_INTERFACE_DETAIL_DATA();

            HidD_GetHidGuid(ref hidGuid);

            // Open a handle to the plug and play dev node.
            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);
            hardwareDeviceInfo = SetupDiGetClassDevs(ref hidGuid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            deviceInfoData.cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DATA));

            Int32 id = 0;
            while (SetupDiEnumDeviceInterfaces(hardwareDeviceInfo, IntPtr.Zero, ref hidGuid, id, ref deviceInfoData))
            {
                int RequiredLength = 0;

                // Allocate a function class device data structure to receive the goods about this particular device.
                SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, ref deviceInfoData, IntPtr.Zero, 0, ref RequiredLength, IntPtr.Zero);

                if (IntPtr.Size == 8)
                    functionClassDeviceData.cbSize = 8;
                else if (IntPtr.Size == 4)
                    functionClassDeviceData.cbSize = 5;

                // Retrieve the information from Plug and Play.
                SetupDiGetDeviceInterfaceDetail(hardwareDeviceInfo, ref deviceInfoData, ref functionClassDeviceData, RequiredLength, ref RequiredLength, IntPtr.Zero);

                // Open device with just generic query abilities to begin with
                OpenDevice(functionClassDeviceData.DevicePath, ref HID_Devices, id);

                id++;
            }

            SetupDiDestroyDeviceInfoList(hardwareDeviceInfo);

            GC.Collect();
            return id;
        }

        bool GetHIDDevice(ref HID_DEVICE hid)
        {
            bool ret = false;
            int nbrDevice = FindDeviceNumber();
            HID_DEVICE[] device = new HID_DEVICE[nbrDevice];

            if(FindKnownDevices(ref device) > 0)
            {
                for (int Index = 0; Index < nbrDevice; Index++)
                {
                    if (device[Index].Attributes.VendorID == VENDOR_ID)
                    {
                        if (device[Index].Attributes.ProductID == PID_JW28A12L)
                        {
                            hid = device[Index];
                            ret = true;
                            break;
                        }
                    }
                }
            }

            GC.Collect();
            return ret;
        }

        bool WriteLEDs(HID_DEVICE HID_Device, byte l0, byte l1, byte l2, byte l3)
        {
            byte[] report = new byte[HID_Device.Caps.InputReportByteLength];
            uint written = 0;

            report[0] = 0x00;   //Report ID
            report[1] = l0;     //Output 0
            report[2] = l1;     //Output 1
            report[3] = l2;     //Output 2
            report[4] = l3;     //Output 3

            return WriteFile(HID_Device.Pointer, report, HID_Device.Caps.InputReportByteLength, ref written, IntPtr.Zero);
        }

        bool ReadJoyWarrior(HID_DEVICE HID_Device, ref JW28A12LData data)
        {
            byte[] report = new byte[HID_Device.Caps.InputReportByteLength];
            uint written = 0;
            
            if (ReadFile(HID_Device.Pointer, report, HID_Device.Caps.InputReportByteLength, ref written, IntPtr.Zero) == true)
            {
                data.axis0 = Convert.ToUInt16((report[2] << 8) | report[1]);
                data.axis1 = Convert.ToUInt16((report[4] << 8) | report[3]);
                data.axis2 = Convert.ToUInt16((report[6] << 8) | report[5]);
                data.axis3 = Convert.ToUInt16((report[8] << 8) | report[7]);
                
                //Default button mode
                data.buttons = report[9];
                
                //For matrix mode you have to select the IO-Pin "matrix"
                data.matrix = 0; // Convert.ToUInt16((report[10] << 11) | report[9]);

                return true;
            }

            return false;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(GetHIDDevice(ref m_Device) == true)
            {
                btnWrite.Enabled = true;
                btnRead.Enabled = true;
                listLog.Items.Add("Connected to first JoyWarrior28A12L found on system");
            }
            else
                listLog.Items.Add("No JoyWarrior28A12L found on system");
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            if(WriteLEDs(m_Device, (byte)cmbOut0.SelectedIndex, (byte)cmbOut1.SelectedIndex, (byte)cmbOut2.SelectedIndex, (byte)cmbOut3.SelectedIndex) == false)
                listLog.Items.Add("Error during write to JoyWarrior28A12L");
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            JW28A12LData data = new JW28A12LData();

            if(ReadJoyWarrior(m_Device, ref data) == true)
            {
                lblAxis0.Text = data.axis0.ToString();
                lblAxis1.Text = data.axis1.ToString();
                lblAxis2.Text = data.axis2.ToString();
                lblAxis3.Text = data.axis3.ToString();

                lblButtons.Text = Convert.ToString(data.buttons, 2).PadLeft(8, '0');
                lblMatrix.Text = Convert.ToString(data.buttons, 2).PadLeft(16, '0');
            }
            else
                listLog.Items.Add("Error during read from JoyWarrior28A12L");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listLog.Items.Clear();
        }
    }
}
