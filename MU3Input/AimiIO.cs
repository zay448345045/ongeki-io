﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MU3Input
{
    public static class AimiIO
    {
        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_get_api_version")]
        public static ushort GetVersion() => 0x0101;

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_init")]
        public static uint Init()
        {
            if (Process.GetCurrentProcess().ProcessName != "amdaemon" &&
                Process.GetCurrentProcess().ProcessName != "Debug" &&
                Process.GetCurrentProcess().ProcessName != "Test")
                return 0;
            
            return 0;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_nfc_poll")]
        public static uint Poll(byte unitNumber)
        {
            return 0;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_nfc_get_felica_id")]
        public static uint GetFelicaId(byte unitNumber, out ulong id)
        {
            id = 0;
            return 1;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_nfc_get_aime_id")]
        public static uint GetAimeId(byte unitNumber, IntPtr id, ulong size)
        {
            if (Mu3Io.Io == null || !Mu3Io.Io.Scan) return 1;
            
            Marshal.Copy(Mu3Io.Io.AimiId, 0, id, 10);
            
            return 0;
        }

        [DllExport(CallingConvention = CallingConvention.Cdecl, ExportName = "aime_io_led_set_color")]
        public static void SetColor(byte unitNumber, byte r, byte g, byte b)
        {
           
        }
    }
}
