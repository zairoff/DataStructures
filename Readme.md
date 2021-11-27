# .NET Mentoring basics Module8

## Implement LinkedList with such function set:

- Length

- Add

- AddAt

- Remove

- RemoveAt

- ElementAt

Implement IEnumerable to make your list work with foreach 

**Note!** you `SHOULD NOT` use *YIELD* operator

## Implement the following interface using single internal item "storage" for both FILO and FIFO flows. Use Double linked list in your implementation. Reusing your code from previous task is desirable.

```cs
public interface IHybridFlowProcessor<T>
{
    void Push<T>(T item);    
    void Enqueue<T>(T item);
    T Dequeue<T>();
    T Pop<T>();
}
```