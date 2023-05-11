namespace JWT_test.Dto.Shared
{
    public class PageResultDto<T>
    {
        public T Item { get; set; }
        public int TotalItem { get; set; }

    }
}
