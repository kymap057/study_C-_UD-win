using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lap_1
{
    class Program
    {
        static void NhapMang(int[,] a, out int n)
        {
            Console.Write("Nhap n= ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Nhap a[{0},{1}] = ", i, j);
                    a[i, j] = Convert.ToInt32(Console.ReadLine());
                }
        }
        static void XuatMang(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j] + "\t");
                Console.WriteLine();
            }
        }
        static int KTNT(int n)
        {
            int dem = 0;
            if (n == 2)
                return 1;
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    if (n % i == 0)
                        dem++;
                }
                if (dem == 1)
                    return 1;
                else
                    return 0;
            }
        }
        static void INCC(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        Console.Write(a[i, j] + "\t");
                    Console.Write(" " + "\t");
                }
                Console.WriteLine();
            }
        }
        static void IN_SNT(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (KTNT(a[i, j]) == 1)
                        Console.Write("{0} ", a[i, j]);
        }
        static int Tong_PT(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    tong += a[i, j];
            return tong;
        }
        static int Tong_SNT(int[,] a, int n)
        {
            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    if (KTNT(a[i, j]) == 1)
                        tong += a[i, j];
            }
            return tong;
        }
        static int Tong_PT_Dongk(int[,] a, int n)
        {
            int tong = 0, k;
            Console.WriteLine("Nhap dong k: ");
            k = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                tong += a[k, i];
            }
            return tong;
        }
        static void Dem_PT_Am_Duong(int[,] a, int n)
        {
            int am = 0;
            int duong = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (a[i, j] < 0)
                        am++;
                    if (a[i, j] > 0)
                        duong++;
                }
            Console.WriteLine("so phan tu am: {0}", am);
            Console.WriteLine("so phan tu duong: {0}", duong);
        }
        static int Dem_X_PT(int[,] a, int n)
        {
            int x;
            Console.WriteLine("nhap so x can dem: ");
            x = Convert.ToInt32(Console.ReadLine());

            int dem = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] == x)
                        dem++;
            return dem;
        }


        static int KTSHT(int n)
        {
            int tich = 1;
            int tong = 0;
            int a = n;
            while (a < 1)
            {
                tich *= a % 10;
                a = a / 10;
            }
            int b = n;
            while (b < 1)
            {
                tong += b % 10;
                b = b / 10;
            }
            if (tong == tich)
                return 1;
            return 0;
        }
        static void In_SHT(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (KTSHT(a[i, j]) == 1)
                        Console.Write("\t{0}", a[i, j]);
                }
        }
        static void VT_PT(int[,] a, int n)
        {
            int dong = -1, cot = -1, x;
            Console.WriteLine("nhap so nguyen n: ");
            x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (a[i, j] == x)
                    {
                        dong = i;
                        cot = j;
                        break;
                    }
            if (dong != -1 && cot != -1)
                Console.WriteLine("so " + x + " nam vi tri[ " + dong + " , " + cot + " ]");
            else
                Console.WriteLine("ko co so nguyen " + n + " trong mang");



        }

        static void Main(string[] args)
        {
            const int MAX = 10;
            int n;
            int[,] a = new int[MAX, MAX];
            NhapMang(a, out n);
            XuatMang(a, n);



            //xuat duong cheo chinh
            Console.WriteLine("Duong cheo chinh:");
            INCC(a, n);
            //xuat so nguyen to
            Console.WriteLine("Cac so nguyen to:");
            IN_SNT(a, n);
            Console.WriteLine();
            //xuat tong cac phan tu
            Console.WriteLine("Tinh tong tat ca phan tu: {0}", Tong_PT(a, n));
            //Tong cac so nguyen to
            Console.WriteLine("Tinh tong tat ca phan tu la so nguyen to: {0}", Tong_SNT(a, n));
            //Tong PT dong K
            Console.WriteLine("Tinh tong tat ca phan tu dong K: {0}", Tong_PT_Dongk(a, n));
            //đếm các phần tử âm, hàm đếm phần tử dương trong ma trận
            Dem_PT_Am_Duong(a, n);
            //đếm số lần xuất hiện của phần tử x trong ma trận
            Console.WriteLine("So lan x xuat hien {0}", Dem_X_PT(a, n));
            //các số hoàn thiện 
            Console.WriteLine("Cac so hoan thien:");
            In_SHT(a, n);
            //vt phan tu n trong mang
            VT_PT(a, n);

            Console.Read();
        }
    }
}
