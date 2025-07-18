// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protocol.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Google.Protobuf.Protocol.Match {

  /// <summary>Holder for reflection information generated from Protocol.proto</summary>
  public static partial class ProtocolReflection {

    #region Descriptor
    /// <summary>File descriptor for Protocol.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ProtocolReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg5Qcm90b2NvbC5wcm90bxIIUHJvdG9jb2waH2dvb2dsZS9wcm90b2J1Zi90",
            "aW1lc3RhbXAucHJvdG8ijgEKCkNfTWF0Y2hpbmcSDQoFdG9rZW4YASABKAkS",
            "MQoJbWF0Y2hJbmZvGAIgASgLMh4uUHJvdG9jb2wuQ19NYXRjaGluZy5NYXRj",
            "aEluZm8aPgoJTWF0Y2hJbmZvEhMKC2NoYXJhY3RlcklkGAEgASgFEg4KBnNr",
            "aW5JZBgCIAEoBRIMCgRtb2RlGAMgASgJIv0BCgpTX01hdGNoaW5nEjMKCmF1",
            "dGhSZXN1bHQYASABKA4yHy5Qcm90b2NvbC5TX01hdGNoaW5nLkF1dGhSZXN1",
            "bHQSDgoGcm9vbUlkGAIgASgJEhAKCHBhc3N3b3JkGAMgASgJEgoKAmlwGAQg",
            "ASgJEgwKBHBvcnQYBSABKAUifgoKQXV0aFJlc3VsdBILCgdTVUNDRVNTEAAS",
            "EQoNSU5WQUxJRF9UT0tFThABEhIKDlVTRVJfTk9UX0ZPVU5EEAISEQoNQUND",
            "RVNTX0RFTklFRBADEhQKEEFMUkVBRFlfSU5fTUFUQ0gQBBITCg9JTlZBTElE",
            "X1JFUVVFU1QQBSonCgVNc2dJZBIOCgpDX01BVENISU5HEAASDgoKU19NQVRD",
            "SElORxABQiGqAh5Hb29nbGUuUHJvdG9idWYuUHJvdG9jb2wuTWF0Y2hiBnBy",
            "b3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.TimestampReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Google.Protobuf.Protocol.Match.MsgId), }, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Match.C_Matching), global::Google.Protobuf.Protocol.Match.C_Matching.Parser, new[]{ "Token", "MatchInfo" }, null, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo), global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo.Parser, new[]{ "CharacterId", "SkinId", "Mode" }, null, null, null, null)}),
            new pbr::GeneratedClrTypeInfo(typeof(global::Google.Protobuf.Protocol.Match.S_Matching), global::Google.Protobuf.Protocol.Match.S_Matching.Parser, new[]{ "AuthResult", "RoomId", "Password", "Ip", "Port" }, null, new[]{ typeof(global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult) }, null, null)
          }));
    }
    #endregion

  }
  #region Enums
  public enum MsgId {
    /// <summary>
    /// 매칭 요청
    /// </summary>
    [pbr::OriginalName("C_MATCHING")] CMatching = 0,
    /// <summary>
    /// 매칭 결과
    /// </summary>
    [pbr::OriginalName("S_MATCHING")] SMatching = 1,
  }

  #endregion

  #region Messages
  public sealed partial class C_Matching : pb::IMessage<C_Matching> {
    private static readonly pb::MessageParser<C_Matching> _parser = new pb::MessageParser<C_Matching>(() => new C_Matching());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<C_Matching> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.Match.ProtocolReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public C_Matching() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public C_Matching(C_Matching other) : this() {
      token_ = other.token_;
      matchInfo_ = other.matchInfo_ != null ? other.matchInfo_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public C_Matching Clone() {
      return new C_Matching(this);
    }

    /// <summary>Field number for the "token" field.</summary>
    public const int TokenFieldNumber = 1;
    private string token_ = "";
    /// <summary>
    /// JWT 토큰
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Token {
      get { return token_; }
      set {
        token_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "matchInfo" field.</summary>
    public const int MatchInfoFieldNumber = 2;
    private global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo matchInfo_;
    /// <summary>
    /// 매칭 정보
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo MatchInfo {
      get { return matchInfo_; }
      set {
        matchInfo_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as C_Matching);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(C_Matching other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Token != other.Token) return false;
      if (!object.Equals(MatchInfo, other.MatchInfo)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Token.Length != 0) hash ^= Token.GetHashCode();
      if (matchInfo_ != null) hash ^= MatchInfo.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Token.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Token);
      }
      if (matchInfo_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(MatchInfo);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Token.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Token);
      }
      if (matchInfo_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(MatchInfo);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(C_Matching other) {
      if (other == null) {
        return;
      }
      if (other.Token.Length != 0) {
        Token = other.Token;
      }
      if (other.matchInfo_ != null) {
        if (matchInfo_ == null) {
          MatchInfo = new global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo();
        }
        MatchInfo.MergeFrom(other.MatchInfo);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Token = input.ReadString();
            break;
          }
          case 18: {
            if (matchInfo_ == null) {
              MatchInfo = new global::Google.Protobuf.Protocol.Match.C_Matching.Types.MatchInfo();
            }
            input.ReadMessage(MatchInfo);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the C_Matching message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class MatchInfo : pb::IMessage<MatchInfo> {
        private static readonly pb::MessageParser<MatchInfo> _parser = new pb::MessageParser<MatchInfo>(() => new MatchInfo());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<MatchInfo> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Google.Protobuf.Protocol.Match.C_Matching.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MatchInfo() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MatchInfo(MatchInfo other) : this() {
          characterId_ = other.characterId_;
          skinId_ = other.skinId_;
          mode_ = other.mode_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public MatchInfo Clone() {
          return new MatchInfo(this);
        }

        /// <summary>Field number for the "characterId" field.</summary>
        public const int CharacterIdFieldNumber = 1;
        private int characterId_;
        /// <summary>
        /// 사용할 캐릭터 ID
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CharacterId {
          get { return characterId_; }
          set {
            characterId_ = value;
          }
        }

        /// <summary>Field number for the "skinId" field.</summary>
        public const int SkinIdFieldNumber = 2;
        private int skinId_;
        /// <summary>
        /// 사용할 스킨 ID
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int SkinId {
          get { return skinId_; }
          set {
            skinId_ = value;
          }
        }

        /// <summary>Field number for the "mode" field.</summary>
        public const int ModeFieldNumber = 3;
        private string mode_ = "";
        /// <summary>
        /// 매칭을 요청할 게임모드
        /// </summary>
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Mode {
          get { return mode_; }
          set {
            mode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as MatchInfo);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(MatchInfo other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (CharacterId != other.CharacterId) return false;
          if (SkinId != other.SkinId) return false;
          if (Mode != other.Mode) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (CharacterId != 0) hash ^= CharacterId.GetHashCode();
          if (SkinId != 0) hash ^= SkinId.GetHashCode();
          if (Mode.Length != 0) hash ^= Mode.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (CharacterId != 0) {
            output.WriteRawTag(8);
            output.WriteInt32(CharacterId);
          }
          if (SkinId != 0) {
            output.WriteRawTag(16);
            output.WriteInt32(SkinId);
          }
          if (Mode.Length != 0) {
            output.WriteRawTag(26);
            output.WriteString(Mode);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (CharacterId != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(CharacterId);
          }
          if (SkinId != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(SkinId);
          }
          if (Mode.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Mode);
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(MatchInfo other) {
          if (other == null) {
            return;
          }
          if (other.CharacterId != 0) {
            CharacterId = other.CharacterId;
          }
          if (other.SkinId != 0) {
            SkinId = other.SkinId;
          }
          if (other.Mode.Length != 0) {
            Mode = other.Mode;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 8: {
                CharacterId = input.ReadInt32();
                break;
              }
              case 16: {
                SkinId = input.ReadInt32();
                break;
              }
              case 26: {
                Mode = input.ReadString();
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  public sealed partial class S_Matching : pb::IMessage<S_Matching> {
    private static readonly pb::MessageParser<S_Matching> _parser = new pb::MessageParser<S_Matching>(() => new S_Matching());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<S_Matching> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Google.Protobuf.Protocol.Match.ProtocolReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Matching() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Matching(S_Matching other) : this() {
      authResult_ = other.authResult_;
      roomId_ = other.roomId_;
      password_ = other.password_;
      ip_ = other.ip_;
      port_ = other.port_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public S_Matching Clone() {
      return new S_Matching(this);
    }

    /// <summary>Field number for the "authResult" field.</summary>
    public const int AuthResultFieldNumber = 1;
    private global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult authResult_ = global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult.Success;
    /// <summary>
    /// 인증 결과
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult AuthResult {
      get { return authResult_; }
      set {
        authResult_ = value;
      }
    }

    /// <summary>Field number for the "roomId" field.</summary>
    public const int RoomIdFieldNumber = 2;
    private string roomId_ = "";
    /// <summary>
    /// 방 식별번호
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string RoomId {
      get { return roomId_; }
      set {
        roomId_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "password" field.</summary>
    public const int PasswordFieldNumber = 3;
    private string password_ = "";
    /// <summary>
    /// 방 비밀번호
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "ip" field.</summary>
    public const int IpFieldNumber = 4;
    private string ip_ = "";
    /// <summary>
    /// 접속할 게임서버 IP
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Ip {
      get { return ip_; }
      set {
        ip_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "port" field.</summary>
    public const int PortFieldNumber = 5;
    private int port_;
    /// <summary>
    /// 접속할 게임서버 포트번호
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as S_Matching);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(S_Matching other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (AuthResult != other.AuthResult) return false;
      if (RoomId != other.RoomId) return false;
      if (Password != other.Password) return false;
      if (Ip != other.Ip) return false;
      if (Port != other.Port) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (AuthResult != global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult.Success) hash ^= AuthResult.GetHashCode();
      if (RoomId.Length != 0) hash ^= RoomId.GetHashCode();
      if (Password.Length != 0) hash ^= Password.GetHashCode();
      if (Ip.Length != 0) hash ^= Ip.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (AuthResult != global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult.Success) {
        output.WriteRawTag(8);
        output.WriteEnum((int) AuthResult);
      }
      if (RoomId.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(RoomId);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(Password);
      }
      if (Ip.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(Ip);
      }
      if (Port != 0) {
        output.WriteRawTag(40);
        output.WriteInt32(Port);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (AuthResult != global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult.Success) {
        size += 1 + pb::CodedOutputStream.ComputeEnumSize((int) AuthResult);
      }
      if (RoomId.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(RoomId);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      if (Ip.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Ip);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Port);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(S_Matching other) {
      if (other == null) {
        return;
      }
      if (other.AuthResult != global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult.Success) {
        AuthResult = other.AuthResult;
      }
      if (other.RoomId.Length != 0) {
        RoomId = other.RoomId;
      }
      if (other.Password.Length != 0) {
        Password = other.Password;
      }
      if (other.Ip.Length != 0) {
        Ip = other.Ip;
      }
      if (other.Port != 0) {
        Port = other.Port;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            AuthResult = (global::Google.Protobuf.Protocol.Match.S_Matching.Types.AuthResult) input.ReadEnum();
            break;
          }
          case 18: {
            RoomId = input.ReadString();
            break;
          }
          case 26: {
            Password = input.ReadString();
            break;
          }
          case 34: {
            Ip = input.ReadString();
            break;
          }
          case 40: {
            Port = input.ReadInt32();
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the S_Matching message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public enum AuthResult {
        /// <summary>
        /// 인증 성공
        /// </summary>
        [pbr::OriginalName("SUCCESS")] Success = 0,
        /// <summary>
        /// 잘못된 토큰
        /// </summary>
        [pbr::OriginalName("INVALID_TOKEN")] InvalidToken = 1,
        /// <summary>
        /// 유저를 찾을 수 없음
        /// </summary>
        [pbr::OriginalName("USER_NOT_FOUND")] UserNotFound = 2,
        /// <summary>
        /// 접근 거부
        /// </summary>
        [pbr::OriginalName("ACCESS_DENIED")] AccessDenied = 3,
        /// <summary>
        /// 이미 매칭 중   
        /// </summary>
        [pbr::OriginalName("ALREADY_IN_MATCH")] AlreadyInMatch = 4,
        /// <summary>
        /// 잘못된 요청 (예: 가지고 있지 않은 캐릭터 ID 요청 등)
        /// </summary>
        [pbr::OriginalName("INVALID_REQUEST")] InvalidRequest = 5,
      }

    }
    #endregion

  }

  #endregion

}

#endregion Designer generated code
