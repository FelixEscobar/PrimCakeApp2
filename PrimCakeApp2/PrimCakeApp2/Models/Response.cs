
namespace PrimCakeApp2.Models
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
    }
}
