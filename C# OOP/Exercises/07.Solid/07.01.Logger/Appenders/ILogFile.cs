namespace Solid.Appenders
{
    interface ILogFile
    {
        void Write(string record);
        int Size { get; }
    }
}
