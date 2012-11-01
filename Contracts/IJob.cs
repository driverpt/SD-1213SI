using System;

namespace Contracts
{
    public interface IJob
    {
        string Executable { get; }
        string Arguments { get; }
        string Status { get; set; }
        Action Callback { get; }
    }
}