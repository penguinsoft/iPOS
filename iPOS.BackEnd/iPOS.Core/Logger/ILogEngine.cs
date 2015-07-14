using System;

namespace iPOS.Core.Logger
{
    public interface ILogEngine
    {
        void Info(string message);

        void Warn(string message);

        void Debug(string message);

        void Error(string message);

        void Error(Exception ex);

        void Error(Exception ex, string message);

        void Fatal(string message);

        void Fatal(Exception ex);

        void Fatal(Exception ex, string message);
    }
}
