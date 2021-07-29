using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmsAboutBack.Helpers
{
    public class Base64Coder
    {
        static public byte[] EncodeImg(string path)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(path);
            return Convert.FromBase64String(Convert.ToBase64String(imageArray));
        }
    }
}
