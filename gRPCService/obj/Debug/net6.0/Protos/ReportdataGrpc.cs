// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/reportdata.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace gRPCService {
  public static partial class Reporter
  {
    static readonly string __ServiceName = "Reporter";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.TestData> __Marshaller_TestData = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.TestData.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.Response> __Marshaller_Response = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.Response.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.TestDataList> __Marshaller_TestDataList = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.TestDataList.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.Action> __Marshaller_Action = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.Action.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.Log> __Marshaller_Log = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.Log.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.TestData, global::gRPCService.Response> __Method_SendTestData = new grpc::Method<global::gRPCService.TestData, global::gRPCService.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendTestData",
        __Marshaller_TestData,
        __Marshaller_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.TestDataList, global::gRPCService.Response> __Method_SendTestDatas = new grpc::Method<global::gRPCService.TestDataList, global::gRPCService.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SendTestDatas",
        __Marshaller_TestDataList,
        __Marshaller_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.Action, global::gRPCService.Response> __Method_DBConnect = new grpc::Method<global::gRPCService.Action, global::gRPCService.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DBConnect",
        __Marshaller_Action,
        __Marshaller_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.Action, global::gRPCService.Response> __Method_DBDisconnect = new grpc::Method<global::gRPCService.Action, global::gRPCService.Response>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DBDisconnect",
        __Marshaller_Action,
        __Marshaller_Response);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.Action, global::gRPCService.Log> __Method_GetGrpcLogs = new grpc::Method<global::gRPCService.Action, global::gRPCService.Log>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetGrpcLogs",
        __Marshaller_Action,
        __Marshaller_Log);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gRPCService.ReportdataReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Reporter</summary>
    [grpc::BindServiceMethod(typeof(Reporter), "BindService")]
    public abstract partial class ReporterBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.Response> SendTestData(global::gRPCService.TestData request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.Response> SendTestDatas(global::gRPCService.TestDataList request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.Response> DBConnect(global::gRPCService.Action request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.Response> DBDisconnect(global::gRPCService.Action request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.Log> GetGrpcLogs(global::gRPCService.Action request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(ReporterBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_SendTestData, serviceImpl.SendTestData)
          .AddMethod(__Method_SendTestDatas, serviceImpl.SendTestDatas)
          .AddMethod(__Method_DBConnect, serviceImpl.DBConnect)
          .AddMethod(__Method_DBDisconnect, serviceImpl.DBDisconnect)
          .AddMethod(__Method_GetGrpcLogs, serviceImpl.GetGrpcLogs).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ReporterBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_SendTestData, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.TestData, global::gRPCService.Response>(serviceImpl.SendTestData));
      serviceBinder.AddMethod(__Method_SendTestDatas, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.TestDataList, global::gRPCService.Response>(serviceImpl.SendTestDatas));
      serviceBinder.AddMethod(__Method_DBConnect, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.Action, global::gRPCService.Response>(serviceImpl.DBConnect));
      serviceBinder.AddMethod(__Method_DBDisconnect, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.Action, global::gRPCService.Response>(serviceImpl.DBDisconnect));
      serviceBinder.AddMethod(__Method_GetGrpcLogs, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.Action, global::gRPCService.Log>(serviceImpl.GetGrpcLogs));
    }

  }
}
#endregion
