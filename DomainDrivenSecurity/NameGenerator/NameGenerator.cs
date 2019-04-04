using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NameGenerator
{
    public class NameGenerator
    {
        public static string GetFirstName()
        {
            return GetName();
        }

        public static string GetLastName()
        {
            return GetName(false);
        }

        private static string GetName(bool firstName = true)
        {
            string execPath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "names.xlsx"), value;
            var rowAndCol = GetRowAndColumn();

            using (ExcelPackage xlPkg = new ExcelPackage(new FileInfo(execPath)))
            {
                value = xlPkg.Workbook.Worksheets.First().Cells[rowAndCol.row, (firstName) ? rowAndCol.column : 3].GetValue<string>();
            }

            return value;
        }

        private static (int row, int column) GetRowAndColumn()
        {
            int col, seed, row;
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] byteArray = new byte[4];

            provider.GetBytes(byteArray);
            seed = Math.Abs((int)BitConverter.ToUInt32(byteArray, 0));

            col = (seed % 2) + 1; //Excel is 1 indexed.

            row = new Random(seed).Next(1, 100);

            return (row, col);
        }
    }
}
