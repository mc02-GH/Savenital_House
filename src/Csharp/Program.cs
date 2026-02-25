using System;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System.IO

namespace SVM2;

public static class S
{


    static UInt16[] sde = {
        0x7255,0x7133,0x0D21,0x0602

    };

    static UInt16[] mem = new UInt16[2000];
    static List<UInt16> stack = new List<UInt16>();
    static UInt16[] cr = new UInt16[4];
    static UInt16 ip = 0;












    public static void Main()
    {
        boot();
        while (ip < sde.Length)
        {
            spre(sde[ip]);
            ip++;
        }



    }










    public static void spre(UInt16 code)
    {
        int op = (code >> 12) & 0xf;
        int ot = (code >> 8) & 0xf;
        int m = (code >> 4) & 0xf;
        int n = (code >> 0) & 0xf;
        int ms = code & 0xff;


        switch (op)
        {
            case 7:
                cr[ot] = (UInt16)ms;
                break;
            case 0:
                switch (ot)
                {
                    case 7:
                        cr[m] = cr[n];
                        break;
                    case 6:
                        Console.Write((char)cr[n]);/
                        break;
                    case 4:
                        Console.Write((char)ms);
                        break;
                    case 5:

                        ConsoleKeyInfo key = Console.ReadKey();
                        cr[n] = key.KeyChar;
                        break;
                    case 0xA:
                        stack.Add(cr[ms]);
                        break;
                    case 0xB:

                        cr[ms] = stack[stack.Count - 1];
                        stack.RemoveAt(stack.Count - 1);
                        break;
                    case 0xC:
                        cr[n] -= cr[m];
                        break;
                    case 0xD:
                        cr[n] += cr[m];
                        break;




                }
                break;


        }


    }
    public static void boot()
    {

    }
}
