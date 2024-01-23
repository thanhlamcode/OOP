using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop
{
    abstract class DaiSo
    {
        // Phương thức abstract
        public abstract void Tinh();
    }
    class SoPhuc : DaiSo
    {
        // Các thuộc tính phần thực và phần ảo của số phức
        public double PhanThuc { get; set; }
        public double PhanAo { get; set; }

        // Constructor
        public SoPhuc(double phanThuc, double phanAo)
        {
            PhanThuc = phanThuc;
            PhanAo = phanAo;
        }

        // Overload phương thức Tinh để tính giá trị module
        public override void Tinh()
        {
            // Tính giá trị module của số phức
            double module = Math.Sqrt(Math.Pow(PhanThuc, 2) + Math.Pow(PhanAo, 2));

            // In kết quả
            Console.WriteLine($"Số phức ({PhanThuc} + {PhanAo}i)\nCó giá trị module là: {module}");
        }
    }

    class Vector2D : DaiSo
    {
        // Các thuộc tính phần thực và phần ảo của vector 2D
        public double PhanThuc { get; set; }
        public double PhanAo { get; set; }

        // Constructor
        public Vector2D(double phanThuc, double phanAo)
        {
            PhanThuc = phanThuc;
            PhanAo = phanAo;
        }

        // Overload phương thức Tinh để trả về giá trị của vector vuông góc
        public override void Tinh()
        {
            // Vector vuông góc có phần thực và phần ảo đảo ngược
            double vectorVuonGocPhanThuc = -PhanAo;
            double vectorVuonGocPhanAo = PhanThuc;

            // In kết quả
            Console.WriteLine($"Vector vuông góc với vector ({PhanThuc}, {PhanAo}) là: ({vectorVuonGocPhanThuc}, {vectorVuonGocPhanAo})");
        }
    }
    class Program
    {
        static Random random = new Random();
        // Phương thức tạo số phức với giá trị ngẫu nhiên
        static SoPhuc taoSP()
        {
            int phanThuc = random.Next(0, 11);  // Giá trị ngẫu nhiên từ 0 đến 10 (bao gồm 0 và 10)
            int phanAo = random.Next(0, 11);     // Giá trị ngẫu nhiên từ 0 đến 10 (bao gồm 0 và 10)

            return new SoPhuc(phanThuc, phanAo);
        }

        // Phương thức tạo vector 2D với giá trị ngẫu nhiên là số nguyên
        static Vector2D taoVector2D()
        {
            int phanThuc = random.Next(0, 11);  // Giá trị ngẫu nhiên từ 0 đến 10 (bao gồm 0 và 10)
            int phanAo = random.Next(0, 11);     // Giá trị ngẫu nhiên từ 0 đến 10 (bao gồm 0 và 10)

            return new Vector2D(phanThuc, phanAo);
        }
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            // Tạo List để lưu trữ các đối tượng đại số
            List<DaiSo> danhSachDaiSo = new List<DaiSo>();

            // Tạo và thêm 20 đối tượng ngẫu nhiên vào danhSachDaiSo
            for (int i = 0; i < 20; i++)
            {
                if (i <= 9)
                {
                    danhSachDaiSo.Add(taoSP());
                }
                else
                {
                    danhSachDaiSo.Add(taoVector2D());
                }
            }

            // In thông tin và kết quả của từng đối tượng trong danhSachDaiSo
            foreach (DaiSo daiSo in danhSachDaiSo)
            {
                daiSo.Tinh();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
