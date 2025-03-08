





using System;

namespace Client.Models
{
  public interface IHeapItem<T> : IComparable<T>
  {
    int HeapIndex { get; set; }
  }
}
