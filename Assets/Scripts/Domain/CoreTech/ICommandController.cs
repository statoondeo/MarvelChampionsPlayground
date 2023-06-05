using System.Collections;

public interface ICommandController
{
    void Enqueue(ICommand command);
    IEnumerator Execute();
    bool IsCommandInQueue(ICommand command);
    void Start();
    void Stop();
}
