// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace FlatSharpTests.Oracle
{

using global::System;
using global::FlatBuffers;

public struct NestedStructs : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static NestedStructs GetRootAsNestedStructs(ByteBuffer _bb) { return GetRootAsNestedStructs(_bb, new NestedStructs()); }
  public static NestedStructs GetRootAsNestedStructs(ByteBuffer _bb, NestedStructs obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public NestedStructs __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public OuterStruct? Outer { get { int o = __p.__offset(4); return o != 0 ? (OuterStruct?)(new OuterStruct()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartNestedStructs(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddOuter(FlatBufferBuilder builder, Offset<OuterStruct> OuterOffset) { builder.AddStruct(0, OuterOffset.Value, 0); }
  public static Offset<NestedStructs> EndNestedStructs(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<NestedStructs>(o);
  }
};


}
