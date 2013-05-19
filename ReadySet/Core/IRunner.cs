using System.Threading.Tasks;
namespace ReadySet.Core
{
    interface IRunner
    {
        void Run(string command);
        Task<string[]> RunAsync(string command);

        string Prompt { get; }
        string Name { get; }
        bool HasOutput { get; }
    }
}
