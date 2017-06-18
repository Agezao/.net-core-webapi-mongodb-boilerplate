using System;

namespace Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int Code { get; set; }
        public string Error { get; set; }
    }
}
