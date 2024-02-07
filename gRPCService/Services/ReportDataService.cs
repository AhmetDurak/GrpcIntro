using Google.Protobuf.Collections;
using Grpc.Core;
using gRPCService.Enums;

namespace gRPCService.Services;

public class ReportDataService : Reporter.ReporterBase
{
    private ILogger<ReportDataService> _logger;
    public ReportDataService(ILogger<ReportDataService> logger)
    {
        _logger = logger;
    }

    public override Task<Response> SendTestDatas(TestDataList request, ServerCallContext context)
    {
        List<Task<Response>> response = new List<Task<Response>>();
        foreach(TestData testData in request.RepeatedTestData)
        {
            var res = SendTestData(testData, context);
            //Console.WriteLine("CurrResponse: " + res.Result.Status);
            response.Add(res);
        }
        return response.All(taskRes => taskRes.Result.Status == new Response{Status = 0}.Status) ? 
                    Task.FromResult(new Response{Status = 0}):
                    Task.FromResult(new Response{Status = -1});
    }

    public override Task<Response> SendTestData(TestData request, ServerCallContext context)
    {
        var tags = new RepeatedField<Tags>
        {
            request.Tag
        };
        var task = Task.Run(() => DBService.WriteData(
            new Data()
            {
                Measurement = request.Measurement,
                ItemID = request.ItemID,
                ItemType = request.ItemType,
                ParentID = request.ParentID,
                Name = request.FieldName,
                Value = request.FieldValue,
                Status = EnumConverter.GetStatus(request.Status),
                Stage = EnumConverter.GetStage(request.Stage),
                Description = request.Description,
                Tags = EnumConverter.GetTags(tags),
                Time = request.Timestamp,

            }.ToString(), ref _logger));
        task.Wait();

        return task;
    }

    public override Task<Response> DBConnect(Action request, ServerCallContext context)
    {
        try
        {
            DBService.Connect();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Task.FromResult(new Response { Status = -1 });
        }
        return Task.FromResult(new Response { Status = 0 });
    }
    public override Task<Response> DBDisconnect(Action request, ServerCallContext context)
    {
        try
        {
            DBService.Disconnect();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return Task.FromResult(new Response { Status = -1 });
        }
        return Task.FromResult(new Response { Status = 0 });
    }

    public override Task<Log> GetGrpcLogs(Action request, ServerCallContext context)
    {
        return Task.FromResult(new Log { LogData = _logger.ToString() });
    }


}
public static class EnumConverter
{
    internal static Enums.Status GetStatus(this TestData.Types.Status status)
    {
        switch (status)
        {
            case TestData.Types.Status.Fail:
                return Enums.Status.fail;
            case TestData.Types.Status.Pass:
                return Enums.Status.pass;
            case TestData.Types.Status.Error:
                return Enums.Status.error;
            default:
                return Enums.Status.none;
        }
    }
    internal static Stage GetStage(this TestData.Types.Stage stage)
    {
        switch (stage)
        {
            case TestData.Types.Stage.Scheduled:
                return Stage.scheduled;
            case TestData.Types.Stage.Finished:
                return Stage.finished;
            case TestData.Types.Stage.Interrupted:
                return Stage.interrupted;
            case TestData.Types.Stage.Pending:
                return Stage.pending;
            default:
                return Stage.none;
        }
    }


    internal static Dictionary<Enums.Tag, object> GetTags(this RepeatedField<Tags> tags)
    {
        var _tags = new Dictionary<Enums.Tag, object>();
        foreach (var tag in tags)
        {
            var _getTag = GetTag(tag);
            if (!_tags.ContainsKey(_getTag.Item1))
                _tags.Add(_getTag.Item1, _getTag.Item2);
            else continue;
        }
        return _tags;
    }
    private static (Enums.Tag, object) GetTag(this Tags tag)
    {
        Enums.Tag _tag = Enums.Tag.WrongTag;
        object? value = "wrongValueEntry";
        switch (tag.Tag)
        {
            case Tag.ParentId:
                _tag = Enums.Tag.ParentID;
                value = tag.ValueStr;
                break;
            case Tag.ItemId:
                _tag = Enums.Tag.ItemID;
                value = tag.ValueStr;
                break;
            case Tag.ItemType:
                _tag = Enums.Tag.ItemType;
                value = tag.ValueStr;
                break;
            case Tag.HistoryId:
                _tag = Enums.Tag.HistoryID;
                value = tag.ValueStr;
                break;
            case Tag.Severity:
                _tag = Enums.Tag.Severity;
                value = tag.ValueStr;
                break;
            case Tag.Epic:
                _tag = Enums.Tag.Epic;
                value = tag.ValueStr;
                break;
            case Tag.FullName:
                _tag = Enums.Tag.FullName;
                value = tag.ValueStr;
                break;
            case Tag.Name:
                _tag = Enums.Tag.Name;
                value = tag.ValueStr;
                break;
            case Tag.Start:
                _tag = Enums.Tag.Start;
                value = tag.ValueInt;
                break;
            case Tag.Stop:
                _tag = Enums.Tag.Stop;
                value = tag.ValueInt;
                break;
            case Tag.Stage:
                _tag = Enums.Tag.Stage;
                value = tag.ValueInt;
                break;
            case Tag.Status:
                _tag = Enums.Tag.Status;
                value = tag.ValueInt;
                break;
            case Tag.LinkType:
                _tag = Enums.Tag.LinkType;
                value = tag.ValueStr;
                break;
            case Tag.Attachment:
                _tag = Enums.Tag.Attachment;
                value = tag.ValueStr;
                break;
            case Tag.Label:
                _tag = Enums.Tag.Label;
                value = tag.ValueStr;
                break;
            case Tag.Parameter:
                _tag = Enums.Tag.Parameter;
                value = tag.ValueStr;
                break;
        }

        return (_tag, value);
    }
}