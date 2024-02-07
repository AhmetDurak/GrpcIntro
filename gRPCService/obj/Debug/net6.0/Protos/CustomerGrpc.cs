// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/customer.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace gRPCService {
  public static partial class Customer
  {
    static readonly string __ServiceName = "Customer";

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
    static readonly grpc::Marshaller<global::gRPCService.CustomerLookupModel> __Marshaller_CustomerLookupModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.CustomerLookupModel.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.CustomerModel> __Marshaller_CustomerModel = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.CustomerModel.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::gRPCService.NewCustomerRequest> __Marshaller_NewCustomerRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCService.NewCustomerRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.CustomerLookupModel, global::gRPCService.CustomerModel> __Method_GetCustomerInfo = new grpc::Method<global::gRPCService.CustomerLookupModel, global::gRPCService.CustomerModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetCustomerInfo",
        __Marshaller_CustomerLookupModel,
        __Marshaller_CustomerModel);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::gRPCService.NewCustomerRequest, global::gRPCService.CustomerModel> __Method_GetNewCustomers = new grpc::Method<global::gRPCService.NewCustomerRequest, global::gRPCService.CustomerModel>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetNewCustomers",
        __Marshaller_NewCustomerRequest,
        __Marshaller_CustomerModel);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gRPCService.CustomerReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Customer</summary>
    [grpc::BindServiceMethod(typeof(Customer), "BindService")]
    public abstract partial class CustomerBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::gRPCService.CustomerModel> GetCustomerInfo(global::gRPCService.CustomerLookupModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task GetNewCustomers(global::gRPCService.NewCustomerRequest request, grpc::IServerStreamWriter<global::gRPCService.CustomerModel> responseStream, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CustomerBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetCustomerInfo, serviceImpl.GetCustomerInfo)
          .AddMethod(__Method_GetNewCustomers, serviceImpl.GetNewCustomers).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CustomerBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetCustomerInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::gRPCService.CustomerLookupModel, global::gRPCService.CustomerModel>(serviceImpl.GetCustomerInfo));
      serviceBinder.AddMethod(__Method_GetNewCustomers, serviceImpl == null ? null : new grpc::ServerStreamingServerMethod<global::gRPCService.NewCustomerRequest, global::gRPCService.CustomerModel>(serviceImpl.GetNewCustomers));
    }

  }
}
#endregion