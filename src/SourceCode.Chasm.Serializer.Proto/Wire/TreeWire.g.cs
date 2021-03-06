// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: TreeWire.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace SourceCode.Chasm.IO.Proto.Wire {

  /// <summary>Holder for reflection information generated from TreeWire.proto</summary>
  public static partial class TreeWireReflection {

    #region Descriptor
    /// <summary>File descriptor for TreeWire.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static TreeWireReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5UcmVlV2lyZS5wcm90bxoOU2hhMVdpcmUucHJvdG8iVAoMVHJlZVdpcmVO",
            "b2RlEgwKBE5hbWUYASABKAkSGwoES2luZBgCIAEoDjINLk5vZGVLaW5kV2ly",
            "ZRIZCgZOb2RlSWQYAyABKAsyCS5TaGExV2lyZSIoCghUcmVlV2lyZRIcCgVO",
            "b2RlcxgBIAMoCzINLlRyZWVXaXJlTm9kZSoiCgxOb2RlS2luZFdpcmUSCAoE",
            "QmxvYhAAEggKBFRyZWUQAUIhqgIeU291cmNlQ29kZS5DaGFzbS5JTy5Qcm90",
            "by5XaXJlYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::SourceCode.Chasm.IO.Proto.Wire.Sha1WireReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::SourceCode.Chasm.IO.Proto.Wire.NodeKindWire), }, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode), global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode.Parser, new[]{ "Name", "Kind", "NodeId" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::SourceCode.Chasm.IO.Proto.Wire.TreeWire), global::SourceCode.Chasm.IO.Proto.Wire.TreeWire.Parser, new[]{ "Nodes" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  /// <summary>
  /// NodeKindWire
  /// </summary>
  public enum NodeKindWire {
    /// <summary>
    /// Default
    /// </summary>
    [pbr::OriginalName("Blob")] Blob = 0,
    [pbr::OriginalName("Tree")] Tree = 1,
  }

  #endregion

  #region Messages
  /// <summary>
  /// TreeWireNode
  /// </summary>
  public sealed partial class TreeWireNode : pb::IMessage<TreeWireNode> {
    private static readonly pb::MessageParser<TreeWireNode> _parser = new pb::MessageParser<TreeWireNode>(() => new TreeWireNode());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TreeWireNode> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SourceCode.Chasm.IO.Proto.Wire.TreeWireReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWireNode() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWireNode(TreeWireNode other) : this() {
      name_ = other.name_;
      kind_ = other.kind_;
      NodeId = other.nodeId_ != null ? other.NodeId.Clone() : null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWireNode Clone() {
      return new TreeWireNode(this);
    }

    /// <summary>Field number for the "Name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "Kind" field.</summary>
    public const int KindFieldNumber = 2;
    private global::SourceCode.Chasm.IO.Proto.Wire.NodeKindWire kind_ = 0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SourceCode.Chasm.IO.Proto.Wire.NodeKindWire Kind {
      get { return kind_; }
      set {
        kind_ = value;
      }
    }

    /// <summary>Field number for the "NodeId" field.</summary>
    public const int NodeIdFieldNumber = 3;
    private global::SourceCode.Chasm.IO.Proto.Wire.Sha1Wire nodeId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::SourceCode.Chasm.IO.Proto.Wire.Sha1Wire NodeId {
      get { return nodeId_; }
      set {
        nodeId_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TreeWireNode);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TreeWireNode other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Kind != other.Kind) return false;
      if (!object.Equals(NodeId, other.NodeId)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Kind != 0) hash ^= Kind.GetHashCode();
      if (nodeId_ != null) hash ^= NodeId.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Kind != 0) {
        output.WriteRawTag(16);
        output.WriteEnum((int) Kind);
      }
      if (nodeId_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(NodeId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Kind != 0) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) Kind);
      }
      if (nodeId_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(NodeId);
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TreeWireNode other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Kind != 0) {
        Kind = other.Kind;
      }
      if (other.nodeId_ != null) {
        if (nodeId_ == null) {
          nodeId_ = new global::SourceCode.Chasm.IO.Proto.Wire.Sha1Wire();
        }
        NodeId.MergeFrom(other.NodeId);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 16: {
            kind_ = (global::SourceCode.Chasm.IO.Proto.Wire.NodeKindWire) input.ReadEnum();
            break;
          }
          case 26: {
            if (nodeId_ == null) {
              nodeId_ = new global::SourceCode.Chasm.IO.Proto.Wire.Sha1Wire();
            }
            input.ReadMessage(nodeId_);
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// TreeWire
  /// </summary>
  public sealed partial class TreeWire : pb::IMessage<TreeWire> {
    private static readonly pb::MessageParser<TreeWire> _parser = new pb::MessageParser<TreeWire>(() => new TreeWire());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<TreeWire> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::SourceCode.Chasm.IO.Proto.Wire.TreeWireReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWire() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWire(TreeWire other) : this() {
      nodes_ = other.nodes_.Clone();
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public TreeWire Clone() {
      return new TreeWire(this);
    }

    /// <summary>Field number for the "Nodes" field.</summary>
    public const int NodesFieldNumber = 1;
    private static readonly pb::FieldCodec<global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode> _repeated_nodes_codec
        = pb::FieldCodec.ForMessage(10, global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode.Parser);
    private readonly pbc::RepeatedField<global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode> nodes_ = new pbc::RepeatedField<global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::SourceCode.Chasm.IO.Proto.Wire.TreeWireNode> Nodes {
      get { return nodes_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as TreeWire);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(TreeWire other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!nodes_.Equals(other.nodes_)) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= nodes_.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      nodes_.WriteTo(output, _repeated_nodes_codec);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += nodes_.CalculateSize(_repeated_nodes_codec);
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(TreeWire other) {
      if (other == null) {
        return;
      }
      nodes_.Add(other.nodes_);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            nodes_.AddEntriesFrom(input, _repeated_nodes_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
