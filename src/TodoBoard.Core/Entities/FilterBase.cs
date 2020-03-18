namespace TodoBoard.Core.Entities
{
  public abstract class FilterBase
  {
    public int Page { get; set; } = 1;

    public int PageCount { get; set; } = 10;
  }
}
