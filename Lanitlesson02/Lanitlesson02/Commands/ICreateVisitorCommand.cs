using System.Threading.Tasks;

namespace Client
{
    public interface ICreateVisitorCommand
    {
        Task<Models.CreateVisitorResponse> Execute(Models.CreateVisitorRequest request);
    }
}
