using WebApi.Models;

namespace WebApi.Services;

public class RequestService : IRequestService
{

    private static readonly List<Request> _dataSource = new List<Request>();
    

    public List<Request> GetAll()
    {
        return _dataSource;
    }

    public Request? GetOne(Guid id)
    {
        return _dataSource.FirstOrDefault(x=>x.Id == id);
        
    }

    public Request Add(Request request)
    {
        _dataSource.Add(request);
        return request;
    }

    public Request Edit(Request request)
    {
        var change = _dataSource.FirstOrDefault(x=>x.Id == request.Id);
        if(change != null)
        change.Title = request.Title;
        change.Complete = request.Complete;
        change.Description = request.Description;
        return change;
    }
    public void Remove(Guid id)
    {
        var target = _dataSource.FirstOrDefault(x=>x.Id == id);
        if(target !=null)
        {
            _dataSource.Remove(target);
        }

    }

    public List<Request> Add(List<Request> requests)
    {
        _dataSource.AddRange(requests);
        return requests;
    }

    public void Remove(List<Guid> ids)
    {
        _dataSource.RemoveAll(x=>ids.Contains(x.Id));
    }
}