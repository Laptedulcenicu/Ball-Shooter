using UnityEngine;

namespace Modules.Common
{
    public interface IApplicationContext
    {
        GameObject Canvas { get; }
        GameObject Player { get; }
    }
}