using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navi.Model
{
    class ImageData
    {
        public ImageData(int id, int userId, string fileName, byte[] data)
        {
            Id = id;
            UserId = userId;
            FileName = fileName;
            Data = data;
        }
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string FileName { get; private set; }
        public byte[] Data { get; private set; }
    }
}
