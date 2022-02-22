namespace WebApi.Services;
using WebApi.Models;

public interface IRequestService
{
    List<Request> GetAll();
    Request GetOne(Guid id);
    Request Add(Request request);
    Request Edit(Request request);
    void Remove(Guid id);
    List<Request> Add(List<Request> requests);
    void Remove(List<Guid> ids);
}