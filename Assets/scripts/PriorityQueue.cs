using UnityEngine;
using UnityEditor;
using System.Collections.Generic;


public enum QueueType { FIFO, LIFO }

public class PriorityQueue<T>
{

    private List<T> queue;
    private QueueType queueType = QueueType.FIFO;

    public PriorityQueue(List<T> queue, QueueType queueType)
    {
        this.queue = queue;
        this.queueType = queueType;
    }
    public void enQueue(T entry) {
        this.queue.Add(entry);
    }
    public T deQueue(T entry)
    {
        T returnedObject = default;

        switch (this.queueType)
        {
            case (QueueType.FIFO):
                returnedObject = this.queue[0];
                this.queue.Remove(returnedObject);
            break;
            case (QueueType.LIFO):
                returnedObject = this.queue[queue.Count - 1];
                this.queue.Remove(returnedObject);
            break;

        }
        return returnedObject;
    }
}