using Runic.FileFormats;
using System;
using System.Linq.Expressions;
using static Runic.Dotnet.Assembly;
using static Runic.Dotnet.Assembly.Heap;
using static Runic.Dotnet.Assembly.MetadataTable;
using static Runic.FileFormats.PortableExecutable.Directories;

namespace Runic.Dotnet
{

    public class AssemblyLoader
    {
        public class Assembly
        {
            PortableExecutable _portableExecutable;
            PortableExecutable.Directories.CLIHeader _cliHeader;

            Runic.Dotnet.Assembly.Heap.StringHeap _stringHeap;
            public Runic.Dotnet.Assembly.Heap.StringHeap StringHeap { get { return _stringHeap; } }
            Runic.Dotnet.Assembly.Heap.BlobHeap _blobHeap;
            public Runic.Dotnet.Assembly.Heap.BlobHeap BlobHeap { get { return _blobHeap; } }
            Runic.Dotnet.Assembly.Heap.GUIDHeap _GUIDHeap;
            public Runic.Dotnet.Assembly.Heap.GUIDHeap GUIDHeap { get { return _GUIDHeap; } }
            Runic.Dotnet.Assembly.Heap.StringHeap _USHeap;
            public Runic.Dotnet.Assembly.Heap.StringHeap USHeap { get { return _USHeap; } }

            Runic.Dotnet.Assembly.MetadataTable[] _metadataTables;
#if NET6_0_OR_GREATER

            Runic.Dotnet.Assembly.MetadataTable.MethodDefTable? _methodDefTable;
            public Runic.Dotnet.Assembly.MetadataTable.MethodDefTable? MethodDefTable { get { return _methodDefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeDefTable? _typeDefTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeDefTable? TypeDefTable { get { return _typeDefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldTable? _fieldTable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldTable? FieldTable { get { return _fieldTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldLayoutTable? _fieldLayoutTable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldLayoutTable? FieldLayoutTable { get { return _fieldLayoutTable; } }
            Runic.Dotnet.Assembly.MetadataTable.MemberRefTable? _memberRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.MemberRefTable? MemberRefTable { get { return _memberRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeRefTable? _typeRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeRefTable? TypeRefTable { get { return _typeRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.AssemblyRefTable? _assemblyRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.AssemblyRefTable? AssemblyRefTable { get { return _assemblyRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.AssemblyTable? _assemblyTable;
            public Runic.Dotnet.Assembly.MetadataTable.AssemblyTable? AssemblyTable { get { return _assemblyTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ModuleRefTable? _moduleRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.ModuleRefTable? ModuleRefTable { get { return _moduleRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ModuleTable? _moduleTable;
            public Runic.Dotnet.Assembly.MetadataTable.ModuleTable? ModuleTable { get { return _moduleTable; } }
            Runic.Dotnet.Assembly.MetadataTable.StandAloneSigTable? _standAloneSigTable;
            public Runic.Dotnet.Assembly.MetadataTable.StandAloneSigTable? StandaloneSigTable { get { return _standAloneSigTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeSpecTable? _typeSpecTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeSpecTable? TypeSpecTable { get { return _typeSpecTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ImplMapTable? _implMapTable;
            public Runic.Dotnet.Assembly.MetadataTable.ImplMapTable? ImplMapTable { get { return _implMapTable; } }
            Runic.Dotnet.Assembly.MetadataTable.EventTable? _eventTable;
            public Runic.Dotnet.Assembly.MetadataTable.EventTable? EventTable { get { return _eventTable; } }
            Runic.Dotnet.Assembly.MetadataTable.PropertyTable? _propertyTable;
            public Runic.Dotnet.Assembly.MetadataTable.PropertyTable? PropertyTable { get { return _propertyTable; } }
            Runic.Dotnet.Assembly.MetadataTable.MethodImplTable? _methodImplTable;
            public Runic.Dotnet.Assembly.MetadataTable.MethodImplTable? MethodImplTable { get { return _methodImplTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ClassLayoutTable? _classLayoutTable;
            public Runic.Dotnet.Assembly.MetadataTable.ClassLayoutTable? ClassLayoutTable { get { return _classLayoutTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FileTable? _fileTable;
            public Runic.Dotnet.Assembly.MetadataTable.FileTable? FileTable { get { return _fileTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ParamTable? _paramTable;
            public Runic.Dotnet.Assembly.MetadataTable.ParamTable? ParamTable { get { return _paramTable; } }
            Runic.Dotnet.Assembly.MetadataTable.EventMapTable? _eventMapTable;
            public Runic.Dotnet.Assembly.MetadataTable.EventMapTable? EventMapTable { get { return _eventMapTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ConstantTable? _constantTable;
            public Runic.Dotnet.Assembly.MetadataTable.ConstantTable? ConstantTable { get { return _constantTable; } }
            Runic.Dotnet.Assembly.MetadataTable.CustomAttributeTable? _customAttributeTable;
            public Runic.Dotnet.Assembly.MetadataTable.CustomAttributeTable? CustomAttributeTable { get { return _customAttributeTable; } }
            Runic.Dotnet.Assembly.MetadataTable.DeclSecurityTable? _declSecurityTable;
            public Runic.Dotnet.Assembly.MetadataTable.DeclSecurityTable? DeclSecurityTable { get { return _declSecurityTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ExportedTypeTable? _exportedTypeTable;
            public Runic.Dotnet.Assembly.MetadataTable.ExportedTypeTable? ExportedTypeTable { get { return _exportedTypeTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldRVATable? _fieldRVATable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldRVATable? FieldRVATable { get { return _fieldRVATable; } }
            Runic.Dotnet.Assembly.MetadataTable.NestedClassTable? _nestedClassTable;
            public Runic.Dotnet.Assembly.MetadataTable.NestedClassTable? NestedClassTable { get { return _nestedClassTable; } }
#else
            Runic.Dotnet.Assembly.MetadataTable.MethodDefTable _methodDefTable;
            public Runic.Dotnet.Assembly.MetadataTable.MethodDefTable MethodDefTable { get { return _methodDefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeDefTable _typeDefTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeDefTable TypeDefTable { get { return _typeDefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldTable _fieldTable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldTable FieldTable { get { return _fieldTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldLayoutTable _fieldLayoutTable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldLayoutTable FieldLayoutTable { get { return _fieldLayoutTable; } }
            Runic.Dotnet.Assembly.MetadataTable.MemberRefTable _memberRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.MemberRefTable MemberRefTable { get { return _memberRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeRefTable _typeRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeRefTable TypeRefTable { get { return _typeRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.AssemblyRefTable _assemblyRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.AssemblyRefTable AssemblyRefTable { get { return _assemblyRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.AssemblyTable _assemblyTable;
            public Runic.Dotnet.Assembly.MetadataTable.AssemblyTable AssemblyTable { get { return _assemblyTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ModuleRefTable _moduleRefTable;
            public Runic.Dotnet.Assembly.MetadataTable.ModuleRefTable ModuleRefTable { get { return _moduleRefTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ModuleTable _moduleTable;
            public Runic.Dotnet.Assembly.MetadataTable.ModuleTable ModuleTable { get { return _moduleTable; } }
            Runic.Dotnet.Assembly.MetadataTable.StandAloneSigTable _standAloneSigTable;
            public Runic.Dotnet.Assembly.MetadataTable.StandAloneSigTable StandaloneSigTable { get { return _standAloneSigTable; } }
            Runic.Dotnet.Assembly.MetadataTable.TypeSpecTable _typeSpecTable;
            public Runic.Dotnet.Assembly.MetadataTable.TypeSpecTable TypeSpecTable { get { return _typeSpecTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ImplMapTable _implMapTable;
            public Runic.Dotnet.Assembly.MetadataTable.ImplMapTable ImplMapTable { get { return _implMapTable; } }
            Runic.Dotnet.Assembly.MetadataTable.EventTable _eventTable;
            public Runic.Dotnet.Assembly.MetadataTable.EventTable EventTable { get { return _eventTable; } }
            Runic.Dotnet.Assembly.MetadataTable.PropertyTable _propertyTable;
            public Runic.Dotnet.Assembly.MetadataTable.PropertyTable PropertyTable { get { return _propertyTable; } }
            Runic.Dotnet.Assembly.MetadataTable.MethodImplTable _methodImplTable;
            public Runic.Dotnet.Assembly.MetadataTable.MethodImplTable MethodImplTable { get { return _methodImplTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ClassLayoutTable _classLayoutTable;
            public Runic.Dotnet.Assembly.MetadataTable.ClassLayoutTable ClassLayoutTable { get { return _classLayoutTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FileTable _fileTable;
            public Runic.Dotnet.Assembly.MetadataTable.FileTable FileTable { get { return _fileTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ParamTable _paramTable;
            public Runic.Dotnet.Assembly.MetadataTable.ParamTable ParamTable { get { return _paramTable; } }
            Runic.Dotnet.Assembly.MetadataTable.EventMapTable _eventMapTable;
            public Runic.Dotnet.Assembly.MetadataTable.EventMapTable EventMapTable { get { return _eventMapTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ConstantTable _constantTable;
            public Runic.Dotnet.Assembly.MetadataTable.ConstantTable ConstantTable { get { return _constantTable; } }
            Runic.Dotnet.Assembly.MetadataTable.CustomAttributeTable _customAttributeTable;
            public Runic.Dotnet.Assembly.MetadataTable.CustomAttributeTable CustomAttributeTable { get { return _customAttributeTable; } }
            Runic.Dotnet.Assembly.MetadataTable.DeclSecurityTable _declSecurityTable;
            public Runic.Dotnet.Assembly.MetadataTable.DeclSecurityTable DeclSecurityTable { get { return _declSecurityTable; } }
            Runic.Dotnet.Assembly.MetadataTable.ExportedTypeTable _exportedTypeTable;
            public Runic.Dotnet.Assembly.MetadataTable.ExportedTypeTable ExportedTypeTable { get { return _exportedTypeTable; } }
            Runic.Dotnet.Assembly.MetadataTable.FieldRVATable _fieldRVATable;
            public Runic.Dotnet.Assembly.MetadataTable.FieldRVATable FieldRVATable { get { return _fieldRVATable; } }
            Runic.Dotnet.Assembly.MetadataTable.NestedClassTable _nestedClassTable;
            public Runic.Dotnet.Assembly.MetadataTable.NestedClassTable NestedClassTable { get { return _nestedClassTable; } }
#endif
            internal Assembly(PortableExecutable input)
            {
                _portableExecutable = input;
                _cliHeader = PortableExecutable.Directories.CLIHeader.Load(_portableExecutable);
#if NET6_0_OR_GREATER
                byte[]? metadataRootData = _portableExecutable.ReadArrayAtRelativeVirtualAddress(_cliHeader.MetadataRootRelativeVirtualAddress, _cliHeader.MetadataSize);
#else
                byte[] metadataRootData = _portableExecutable.ReadArrayAtRelativeVirtualAddress(_cliHeader.MetadataRootRelativeVirtualAddress, _cliHeader.MetadataSize);
#endif
                Dotnet.Assembly.MetadataRoot metadataRoot = Dotnet.Assembly.MetadataRoot.Load(_cliHeader.MetadataRootRelativeVirtualAddress, metadataRootData, 0);
                foreach (var stream in metadataRoot.Streams)
                {
                    if (stream.Name == "#~")
                    {
                        byte[] metadataTableData = _portableExecutable.ReadArrayAtRelativeVirtualAddress(stream.RelativeVirtualAddress, stream.Size);
                        using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(metadataTableData))
                        {
                            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(memoryStream))
                            {
                                _metadataTables = Runic.Dotnet.Assembly.MetadataTable.Load(reader, metadataRoot, out _stringHeap, out _blobHeap, out _GUIDHeap);
                                foreach (Runic.Dotnet.Assembly.MetadataTable table in _metadataTables)
                                {
                                    switch (table)
                                    {
                                        case Runic.Dotnet.Assembly.MetadataTable.MethodDefTable methodDefTable: _methodDefTable = methodDefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.TypeDefTable typeDefTable: _typeDefTable = typeDefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.FieldTable fieldTable: _fieldTable = fieldTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.FieldLayoutTable fieldLayoutTable: _fieldLayoutTable = fieldLayoutTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.MemberRefTable memberRefTable: _memberRefTable = memberRefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.TypeRefTable typeRefTable: _typeRefTable = typeRefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.AssemblyRefTable assemblyRefTable: _assemblyRefTable = assemblyRefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.AssemblyTable assemblyTable: _assemblyTable = assemblyTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ModuleTable moduleTable: _moduleTable = moduleTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ModuleRefTable moduleRefTable: _moduleRefTable = moduleRefTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.StandAloneSigTable standAloneSigTable: _standAloneSigTable = standAloneSigTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.TypeSpecTable typeSpecTable: _typeSpecTable = typeSpecTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ImplMapTable implMapTable: _implMapTable = implMapTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.EventTable eventTable: _eventTable = eventTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.PropertyTable propertyTable: _propertyTable = propertyTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.MethodImplTable methodImplTable: _methodImplTable = methodImplTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ClassLayoutTable classLayoutTable: _classLayoutTable = classLayoutTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ParamTable paramTable: _paramTable = paramTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.EventMapTable eventMapTable: _eventMapTable = eventMapTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ConstantTable constantTable: _constantTable = constantTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.CustomAttributeTable customAttributeTable: _customAttributeTable = customAttributeTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.FileTable fileTable: _fileTable = fileTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.DeclSecurityTable declSecurityTable: _declSecurityTable = declSecurityTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.ExportedTypeTable exportedTypeTable: _exportedTypeTable = exportedTypeTable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.FieldRVATable fieldRVATable: _fieldRVATable = fieldRVATable; break;
                                        case Runic.Dotnet.Assembly.MetadataTable.NestedClassTable nestedClassTable: _nestedClassTable = nestedClassTable; break;
                                    }
                                }
                            }
                            if (stream.Name == "#US")
                            {
                                _USHeap = new Runic.Dotnet.Assembly.Heap.StringHeap(true, stream.RelativeVirtualAddress, stream.Size);
                            }
                        }
                    }
                }
            }

#if NET6_0_OR_GREATER
            public string? ReadString(Runic.Dotnet.Assembly.Heap.StringHeap.String? @string)
#else
            public string ReadString(Runic.Dotnet.Assembly.Heap.StringHeap.String @string)
#endif
            {
                if (@string == null) { return null; }
                return _portableExecutable.ReadUTF8StringAtRelativeVirtualAddress(@string.RelativeVirtualAddress);
            }
            uint ReadCompressedIntegerAtRelativeVirtualAddress(uint relativeVirtualAddress, out uint offset)
            {
                offset = 0;
#if NET6_0_OR_GREATER
                byte[]? data = _portableExecutable.ReadArrayAtRelativeVirtualAddress(relativeVirtualAddress, 4);
#else
                byte[] data = _portableExecutable.ReadArrayAtRelativeVirtualAddress(relativeVirtualAddress, 4);
#endif
                if (data == null) { offset = 0; return 0; }
                byte firstByte = data[0];
                if ((firstByte & 0x80) == 0) { offset = 1; return (uint)firstByte; }
                byte secondByte = data[1];
                if ((firstByte & 0x40) == 0) { offset = 2; return (uint)(((uint)firstByte << 8) | (uint)secondByte) & 0x3FFF; }
                byte thirdByte = data[2];
                byte forthByte = data[3];
                offset = 4;
                return (uint)(((uint)firstByte << 24) | ((uint)secondByte << 16) | ((uint)thirdByte << 8) | ((uint)forthByte));
            }
#if NET6_0_OR_GREATER
            public byte[]? ReadByteArray(Runic.Dotnet.Assembly.Heap.BlobHeap.Blob? blob)
#else
            public byte[] ReadByteArray(Runic.Dotnet.Assembly.Heap.BlobHeap.Blob blob)
#endif
            {
                uint offset;
                if (blob == null) { return null; }
                uint length = ReadCompressedIntegerAtRelativeVirtualAddress(blob.Heap.RelativeVirtualAddress + blob.Index, out offset);
                return _portableExecutable.ReadArrayAtRelativeVirtualAddress(blob.Heap.RelativeVirtualAddress + blob.Index + offset, length);
            }
#if NET6_0_OR_GREATER
            public byte[]? ReadByteArray(uint rva, uint length)
#else
            public byte[] ReadByteArray(uint rva, uint length)
#endif
            {
                return _portableExecutable.ReadArrayAtRelativeVirtualAddress(rva, length);
            }

#if NET6_0_OR_GREATER
            public byte[]? ReadMethodHeader(uint rva)
#else
            public byte[] ReadMethodHeader(uint rva)
#endif
            {
                if (rva == 0) { return null; }
                byte[] tinyMethodHeader = _portableExecutable.ReadArrayAtRelativeVirtualAddress(rva, 1);
                if (tinyMethodHeader == null || tinyMethodHeader.Length == 0) { return null; }
                bool useTinyMethodHeader = (tinyMethodHeader[0] & 0x3) == 0x2;
                if (useTinyMethodHeader) { return tinyMethodHeader; }
                byte[] fatMethodHeader = _portableExecutable.ReadArrayAtRelativeVirtualAddress(rva, 12);
                return fatMethodHeader;
            }
#if NET6_0_OR_GREATER
            public byte[]? ReadMethodHeader(Runic.Dotnet.Assembly.MetadataTable.MethodDefTable.MethodDefTableRow methodDef)
#else
            public byte[] ReadMethodHeader(Runic.Dotnet.Assembly.MetadataTable.MethodDefTable.MethodDefTableRow methodDef)
#endif
            {
                if (methodDef == null) { return null; }
                if (methodDef.MethodBodyRelativeVirtualAddress == 0) { return null; }
                return ReadMethodHeader(methodDef.MethodBodyRelativeVirtualAddress);
            }
#if NET6_0_OR_GREATER
            public void ReadMethodHeaderAndBody(Runic.Dotnet.Assembly.MetadataTable.MethodDefTable.MethodDefTableRow methodDef, out byte[]? methodHeader, out byte[]? methodBody)
#else
            public void ReadMethodHeaderAndBody(Runic.Dotnet.Assembly.MetadataTable.MethodDefTable.MethodDefTableRow methodDef, out byte[] methodHeader, out byte[] methodBody)
#endif
            {
                if (methodDef == null) { methodHeader = null; methodBody = null; return; }
                if (methodDef.MethodBodyRelativeVirtualAddress == 0) { methodHeader = null; methodBody = null; return; }
                methodHeader = ReadMethodHeader(methodDef.MethodBodyRelativeVirtualAddress);
                int ilLength = 0;
                Dotnet.Assembly.MethodHeader.Decode(methodHeader, out ilLength, out _, out _, out _, out _);
                methodBody = ReadByteArray(methodDef.MethodBodyRelativeVirtualAddress + (uint)methodHeader.Length, (uint)ilLength);
            }

#if NET6_0_OR_GREATER
            public Guid ReadGUID(Runic.Dotnet.Assembly.Heap.GUIDHeap.GUID? guid)
#else
            public Guid ReadGUID(Runic.Dotnet.Assembly.Heap.GUIDHeap.GUID guid)
#endif
            {
                if (guid == null) { return Guid.Empty; }
#if NET6_0_OR_GREATER
                byte[]? data = _portableExecutable.ReadArrayAtRelativeVirtualAddress(guid.Heap.RelativeVirtualAddress + (guid.Index * 16), 16);
#else
                byte[] data = _portableExecutable.ReadArrayAtRelativeVirtualAddress(guid.Heap.RelativeVirtualAddress + (guid.Index * 16), 16);
#endif
                if (data == null) { return Guid.Empty; }
             
                return new Guid(data);
            }
        }
        public static Assembly Load(System.IO.BinaryReader input)
        {
            return new Assembly(PortableExecutable.Load(input));
        }
#if NET6_0_OR_GREATER
        public static Assembly Load(Span<byte> data, uint offset)
        {
            return new Assembly(PortableExecutable.Load(data, offset));
        }
#endif
    }
}