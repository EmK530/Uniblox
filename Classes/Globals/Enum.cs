// Generated from the API dump of Roblox version 0.700.0.7000935
// https://raw.githubusercontent.com/MaximumADHD/Roblox-Client-Tracker/4fd511d1a952c18433e2ebdbc247713f3692471c/Full-API-Dump.json

public static class Enum
{
    public enum AccessModifierType
    {
        Allow = 0,
        Deny
    }
    public enum AccessoryType
    {
        Unknown = 0,
        Hat,
        Hair,
        Face,
        Neck,
        Shoulder,
        Front,
        Back,
        Waist,
        TShirt,
        Shirt,
        Pants,
        Jacket,
        Sweater,
        Shorts,
        LeftShoe,
        RightShoe,
        DressSkirt,
        Eyebrow,
        Eyelash
    }
    public enum ActionOnAutoResumeSync
    {
        DontResume = 0,
        KeepStudio,
        KeepLocal
    }
    public enum ActionOnStopSync
    {
        AlwaysAsk = 0,
        KeepLocalFiles,
        DeleteLocalFiles
    }
    public enum ActionType
    {
        Nothing = 0,
        Pause,
        Lose,
        Draw,
        Win
    }
    public enum ActuatorRelativeTo
    {
        Attachment0 = 0,
        Attachment1,
        World
    }
    public enum ActuatorType
    {
        None = 0,
        Motor,
        Servo
    }
    public enum AdAvailabilityResult
    {
        IsAvailable = 1,
        DeviceIneligible,
        ExperienceIneligible,
        InternalError,
        NoFill,
        PlayerIneligible,
        PublisherIneligible
    }
    public enum AdEventType
    {
        RewardedAdLoaded = 3,
        RewardedAdGrant,
        RewardedAdUnloaded,
        VideoLoaded = 0,
        VideoRemoved,
        UserCompletedVideo
    }
    public enum AdFormat
    {
        RewardedVideo = 0
    }
    public enum AdShape
    {
        HorizontalRectangle = 1
    }
    public enum AdTeleportMethod
    {
        Undefined = 0,
        PortalForward,
        InGameMenuBackButton,
        UIBackButton
    }
    public enum AdUIEventType
    {
        AdLabelClicked = 0,
        VolumeButtonClicked,
        FullscreenButtonClicked,
        PlayButtonClicked,
        PauseButtonClicked,
        CloseButtonClicked,
        WhyThisAdClicked,
        PlayEventTriggered,
        PauseEventTriggered
    }
    public enum AdUIType
    {
        None = 0,
        Image,
        Video
    }
    public enum AdUnitStatus
    {
        Inactive = 0,
        Active
    }
    public enum AdornCullingMode
    {
        Automatic = 0,
        Never
    }
    public enum AdornShading
    {
        Default = 0,
        Shaded,
        XRay,
        XRayShaded,
        AlwaysOnTop
    }
    public enum AlignType
    {
        PrimaryAxisParallel = 2,
        PrimaryAxisPerpendicular,
        PrimaryAxisLookAt,
        AllAxes,
        Parallel = 0,
        Perpendicular
    }
    public enum AlphaMode
    {
        Overlay = 0,
        Transparency,
        TintMask
    }
    public enum AnalyticsCustomFieldKeys
    {
        CustomField01 = 0,
        CustomField02,
        CustomField03
    }
    public enum AnalyticsEconomyAction
    {
        Default = 0,
        Acquire,
        Spend
    }
    public enum AnalyticsEconomyFlowType
    {
        Sink = 0,
        Source
    }
    public enum AnalyticsEconomyTransactionType
    {
        IAP = 0,
        Shop,
        Gameplay,
        ContextualPurchase,
        TimedReward,
        Onboarding
    }
    public enum AnalyticsLogLevel
    {
        Trace = 0,
        Debug,
        Information,
        Warning,
        Error,
        Fatal
    }
    public enum AnalyticsProgressionStatus
    {
        Default = 0,
        Begin,
        Complete,
        Abandon,
        Fail
    }
    public enum AnalyticsProgressionType
    {
        Custom = 0,
        Start,
        Fail,
        Complete
    }
    public enum AnimationClipFromVideoStatus
    {
        Initializing = 0,
        Pending,
        Processing,
        ErrorGeneric = 4,
        Success = 6,
        ErrorVideoTooLong,
        ErrorNoPersonDetected,
        ErrorVideoUnstable,
        Timeout,
        Cancelled,
        ErrorMultiplePeople,
        ErrorUploadingVideo = 2001
    }
    public enum AnimationNodePlayMode
    {
        Loop = 0,
        PingPong,
        OnceAndHold,
        OnceAndReset
    }
    public enum AnimationNodeTransitionType
    {
        CrossFade = 0,
        InertialBlend,
        DeadBlend
    }
    public enum AnimationNodeType
    {
        InvalidNode = 0,
        AddNode,
        BlendNode,
        Blend1DNode,
        Blend2DNode,
        ClipNode,
        GraphOutput,
        MaskNode,
        PrioritySelectNode,
        RandomSequenceNode,
        SelectNode,
        SequenceNode,
        SpeedNode,
        SubtractNode
    }
    public enum AnimationPriority
    {
        Core = 1000,
        Idle = 0,
        Movement,
        Action,
        Action2,
        Action3,
        Action4
    }
    public enum AnimatorRetargetingMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum AnnotationChannelContentPreference
    {
        None = 0,
        All,
        Unknown
    }
    public enum AnnotationEditingMode
    {
        None = 0,
        PlacingNew,
        WritingNew
    }
    public enum AnnotationPlaceContentPreference
    {
        None = 0,
        All,
        MentionsAndReplies,
        Unknown
    }
    public enum AnnotationRequestStatus
    {
        Success = 0,
        Loading,
        ErrorInternalFailure,
        ErrorNotFound,
        ErrorModerated
    }
    public enum AnnotationRequestType
    {
        Unknown = 0,
        Create,
        Resolve,
        Delete,
        Edit
    }
    public enum AppLifecycleManagerState
    {
        Detached = 0,
        Active,
        Inactive,
        Hidden
    }
    public enum AppShellActionType
    {
        None = 0,
        OpenApp,
        TapChatTab,
        TapConversationEntry,
        TapAvatarTab,
        ReadConversation,
        TapGamePageTab,
        TapHomePageTab,
        GamePageLoaded,
        HomePageLoaded,
        AvatarEditorPageLoaded
    }
    public enum AppShellFeature
    {
        None = 0,
        Chat,
        AvatarEditor,
        GamePage,
        HomePage,
        More,
        Landing
    }
    public enum AppUpdateStatus
    {
        Unknown = 0,
        NotSupported,
        Failed,
        NotAvailable,
        Available,
        AvailableBoundChannel,
        AvailableBetaProgram
    }
    public enum ApplyStrokeMode
    {
        Contextual = 0,
        Border
    }
    public enum AspectType
    {
        FitWithinMaxSize = 0,
        ScaleWithParentSize
    }
    public enum AssetCreatorType
    {
        User = 0,
        Group
    }
    public enum AssetFetchStatus
    {
        Success = 0,
        Failure,
        None,
        Loading,
        TimedOut
    }
    public enum AssetType
    {
        Image = 1,
        TShirt,
        Audio,
        Mesh,
        Lua,
        Hat = 8,
        Place,
        Model,
        Shirt,
        Pants,
        Decal,
        Head = 17,
        Face,
        Gear,
        Badge = 21,
        Animation = 24,
        Torso = 27,
        RightArm,
        LeftArm,
        LeftLeg,
        RightLeg,
        Package,
        GamePass = 34,
        Plugin = 38,
        MeshPart = 40,
        HairAccessory,
        FaceAccessory,
        NeckAccessory,
        ShoulderAccessory,
        FrontAccessory,
        BackAccessory,
        WaistAccessory,
        ClimbAnimation,
        DeathAnimation,
        FallAnimation,
        IdleAnimation,
        JumpAnimation,
        RunAnimation,
        SwimAnimation,
        WalkAnimation,
        PoseAnimation,
        EmoteAnimation = 61,
        Video,
        TShirtAccessory = 64,
        ShirtAccessory,
        PantsAccessory,
        JacketAccessory,
        SweaterAccessory,
        ShortsAccessory,
        LeftShoeAccessory,
        RightShoeAccessory,
        DressSkirtAccessory,
        FontFamily,
        EyebrowAccessory = 76,
        EyelashAccessory,
        MoodAnimation,
        DynamicHead,
        FaceMakeup = 88,
        LipMakeup,
        EyeMakeup,
        EarAccessory = 57,
        EyeAccessory
    }
    public enum AssetTypeVerification
    {
        Default = 1,
        ClientOnly,
        Always
    }
    public enum AudioApiRollout
    {
        Disabled = 0,
        Automatic,
        Enabled
    }
    public enum AudioCaptureMode
    {
    }
    public enum AudioChannelLayout
    {
        Mono = 0,
        Stereo,
        Quad,
        Surround_5,
        Surround_5_1,
        Surround_7_1,
        Surround_7_1_4
    }
    public enum AudioFilterType
    {
        Peak = 0,
        LowShelf,
        HighShelf,
        Lowpass12dB,
        Lowpass24dB,
        Lowpass48dB,
        Highpass12dB,
        Highpass24dB,
        Highpass48dB,
        Bandpass,
        Notch,
        Lowpass6dB
    }
    public enum AudioSimulationFidelity
    {
        None = 0,
        Automatic
    }
    public enum AudioSubType
    {
        Music = 1,
        SoundEffect
    }
    public enum AudioWindowSize
    {
        Small = 0,
        Medium,
        Large
    }
    public enum AuthorityMode
    {
        Server = 0,
        Automatic
    }
    public enum AutoIndentRule
    {
        Off = 0,
        Absolute,
        Relative
    }
    public enum AutomaticSize
    {
        None = 0,
        X,
        Y,
        XY
    }
    public enum AvatarAssetType
    {
        TShirt = 2,
        Hat = 8,
        Shirt = 11,
        Pants,
        Head = 17,
        Face,
        Gear,
        Torso = 27,
        RightArm,
        LeftArm,
        LeftLeg,
        RightLeg,
        HairAccessory = 41,
        FaceAccessory,
        NeckAccessory,
        ShoulderAccessory,
        FrontAccessory,
        BackAccessory,
        WaistAccessory,
        ClimbAnimation,
        FallAnimation = 50,
        IdleAnimation,
        JumpAnimation,
        RunAnimation,
        SwimAnimation,
        WalkAnimation,
        MoodAnimation = 78,
        EmoteAnimation = 61,
        TShirtAccessory = 64,
        ShirtAccessory,
        PantsAccessory,
        JacketAccessory,
        SweaterAccessory,
        ShortsAccessory,
        LeftShoeAccessory,
        RightShoeAccessory,
        DressSkirtAccessory,
        EyebrowAccessory = 76,
        EyelashAccessory,
        DynamicHead = 79,
        FaceMakeup = 88,
        LipMakeup,
        EyeMakeup
    }
    public enum AvatarChatServiceFeature
    {
        None = 0,
        UniverseAudio,
        UniverseVideo,
        PlaceAudio = 4,
        PlaceVideo = 8,
        UserAudioEligible = 16,
        UserAudio = 32,
        UserVideoEligible = 64,
        UserVideo = 128,
        UserBanned = 256,
        UserVerifiedForVoice = 512
    }
    public enum AvatarContextMenuOption
    {
        Friend = 0,
        Chat,
        Emote,
        InspectMenu
    }
    public enum AvatarGenerationError
    {
        None = 0,
        Unknown,
        DownloadFailed,
        Canceled,
        Offensive,
        Timeout,
        JobNotFound
    }
    public enum AvatarItemType
    {
        Asset = 1,
        Bundle
    }
    public enum AvatarPromptResult
    {
        Success = 1,
        PermissionDenied,
        Failed
    }
    public enum AvatarSettingsAccessoryLimitMethod
    {
        Scale = 0,
        Remove,
        PreviewScale,
        PreviewRemove
    }
    public enum AvatarSettingsAccessoryMode
    {
        PlayerChoice = 0,
        CustomLimit
    }
    public enum AvatarSettingsAnimationClipsMode
    {
        PlayerChoice = 0,
        CustomClips
    }
    public enum AvatarSettingsAnimationPacksMode
    {
        PlayerChoice = 0,
        StandardR15,
        StandardR6
    }
    public enum AvatarSettingsAppearanceMode
    {
        PlayerChoice = 0,
        CustomParts,
        CustomBody
    }
    public enum AvatarSettingsBuildMode
    {
        PlayerChoice = 0,
        CustomBuild
    }
    public enum AvatarSettingsClothingMode
    {
        PlayerChoice = 0,
        CustomLimit
    }
    public enum AvatarSettingsCollisionMode
    {
        Default = 0,
        SingleCollider,
        Legacy
    }
    public enum AvatarSettingsCustomAccessoryMode
    {
        PlayerChoice = 0,
        CustomAccessories
    }
    public enum AvatarSettingsCustomBodyType
    {
        AvatarReference = 0,
        BundleId
    }
    public enum AvatarSettingsCustomClothingMode
    {
        PlayerChoice = 0,
        CustomClothing
    }
    public enum AvatarSettingsHitAndTouchDetectionMode
    {
        UseParts = 0,
        UseCollider
    }
    public enum AvatarSettingsJumpMode
    {
        JumpHeight = 0,
        JumpPower
    }
    public enum AvatarSettingsLegacyCollisionMode
    {
        R6Colliders = 0,
        InnerBoxColliders
    }
    public enum AvatarSettingsScaleMode
    {
        PlayerChoice = 0,
        CustomScale
    }
    public enum AvatarThumbnailCustomizationType
    {
        Closeup = 1,
        FullBody
    }
    public enum AvatarUnificationMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum Axis
    {
        X = 0,
        Y,
        Z
    }
    public enum BenefitType
    {
        DeveloperProduct = 0,
        AvatarAsset,
        AvatarBundle
    }
    public enum BinType
    {
        Script = 0,
        GameTool,
        Grab,
        Clone,
        Hammer
    }
    public enum BodyPart
    {
        Head = 0,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg
    }
    public enum BodyPartR15
    {
        Head = 0,
        UpperTorso,
        LowerTorso,
        LeftFoot,
        LeftLowerLeg,
        LeftUpperLeg,
        RightFoot,
        RightLowerLeg,
        RightUpperLeg,
        LeftHand,
        LeftLowerArm,
        LeftUpperArm,
        RightHand,
        RightLowerArm,
        RightUpperArm,
        RootPart,
        Unknown = 17
    }
    public enum BorderMode
    {
        Outline = 0,
        Middle,
        Inset
    }
    public enum BorderStrokePosition
    {
        Outer = 0,
        Center,
        Inner
    }
    public enum BreakReason
    {
        Other = 0,
        Error,
        SpecialBreakpoint,
        UserBreakpoint
    }
    public enum BreakpointRemoveReason
    {
        Requested = 0,
        ScriptChanged,
        ScriptRemoved
    }
    public enum BulkMoveMode
    {
        FireAllEvents = 0,
        FireCFrameChanged
    }
    public enum BundleType
    {
        BodyParts = 1,
        Animations,
        Shoes,
        DynamicHead,
        DynamicHeadAvatar
    }
    public enum Button
    {
        Jump = 32,
        Dismount = 8
    }
    public enum ButtonStyle
    {
        Custom = 0,
        RobloxButtonDefault,
        RobloxButton,
        RobloxRoundButton,
        RobloxRoundDefaultButton,
        RobloxRoundDropdownButton
    }
    public enum CageType
    {
        Inner = 0,
        Outer
    }
    public enum CameraMode
    {
        Classic = 0,
        LockFirstPerson
    }
    public enum CameraPanMode
    {
        Classic = 0,
        EdgeBump
    }
    public enum CameraSpeedAdjustBinding
    {
        None = 0,
        RmbScroll,
        AltScroll
    }
    public enum CameraType
    {
        Fixed = 0,
        Attach,
        Watch,
        Track,
        Follow,
        Custom,
        Scriptable,
        Orbital
    }
    public enum CaptureGalleryPermission
    {
        ReadAndUpload = 0
    }
    public enum CaptureType
    {
        Screenshot = 1,
        Video
    }
    public enum CatalogCategoryFilter
    {
        None = 1,
        Featured,
        Collectibles,
        CommunityCreations,
        Premium,
        Recommended
    }
    public enum CatalogSortAggregation
    {
        Past12Hours = 1,
        PastDay,
        Past3Days,
        PastWeek,
        PastMonth,
        AllTime
    }
    public enum CatalogSortType
    {
        Relevance = 1,
        PriceHighToLow,
        PriceLowToHigh,
        MostFavorited = 5,
        RecentlyCreated,
        Bestselling
    }
    public enum CatalogTimedOptionFilter
    {
        All = 1,
        TimedOptionOnly
    }
    public enum CellBlock
    {
        Solid = 0,
        VerticalWedge,
        CornerWedge,
        InverseCornerWedge,
        HorizontalWedge
    }
    public enum CellMaterial
    {
        Empty = 0,
        Grass,
        Sand,
        Brick,
        Granite,
        Asphalt,
        Iron,
        Aluminum,
        Gold,
        WoodPlank,
        WoodLog,
        Gravel,
        CinderBlock,
        MossyStone,
        Cement,
        RedPlastic,
        BluePlastic,
        Water
    }
    public enum CellOrientation
    {
        NegZ = 0,
        X,
        Z,
        NegX
    }
    public enum CenterDialogType
    {
        UnsolicitedDialog = 1,
        PlayerInitiatedDialog,
        ModalDialog,
        QuitDialog
    }
    public enum CharacterControlMode
    {
        Default = 0,
        Legacy,
        NoCharacterController,
        LuaCharacterController
    }
    public enum ChatCallbackType
    {
        OnCreatingChatWindow = 1,
        OnClientSendingMessage,
        OnClientFormattingMessage,
        OnServerReceivingMessage = 17
    }
    public enum ChatColor
    {
        Blue = 0,
        Green,
        Red,
        White
    }
    public enum ChatMode
    {
        Menu = 0,
        TextAndMenu
    }
    public enum ChatPrivacyMode
    {
        AllUsers = 0,
        NoOne,
        Friends
    }
    public enum ChatRestrictionStatus
    {
        Unknown = 0,
        NotRestricted,
        Restricted
    }
    public enum ChatStyle
    {
        Classic = 0,
        Bubble,
        ClassicAndBubble
    }
    public enum ChatVersion
    {
        LegacyChatService = 0,
        TextChatService
    }
    public enum ClientAnimatorThrottlingMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum CloseReason
    {
        Unknown = 0,
        RobloxMaintenance,
        DeveloperShutdown,
        DeveloperUpdate,
        ServerEmpty,
        OutOfMemory
    }
    public enum CollaboratorStatus
    {
        None = 0,
        Editing3D,
        Scripting,
        PrivateScripting
    }
    public enum CollisionFidelity
    {
        Default = 0,
        Hull,
        Box,
        PreciseConvexDecomposition
    }
    public enum CommandPermission
    {
        Plugin = 0,
        LocalUser
    }
    public enum CompileTarget
    {
        Client = 0,
        CoreScript,
        Studio,
        CoreScriptRaw
    }
    public enum CompletionAcceptanceBehavior
    {
        Insert = 0,
        Replace,
        ReplaceOnEnterInsertOnTab,
        InsertOnEnterReplaceOnTab
    }
    public enum CompletionItemKind
    {
        Text = 1,
        Method,
        Function,
        Constructor,
        Field,
        Variable,
        Class,
        Interface,
        Module,
        Property,
        Unit,
        Value,
        Enum,
        Keyword,
        Snippet,
        Color,
        File,
        Reference,
        Folder,
        EnumMember,
        Constant,
        Struct,
        Event,
        Operator,
        TypeParameter
    }
    public enum CompletionItemTag
    {
        Deprecated = 1,
        IncorrectIndexType,
        PluginPermissions,
        CommandLinePermissions,
        RobloxPermissions,
        AddParens,
        PutCursorInParens,
        TypeCorrect,
        ClientServerBoundaryViolation,
        Invalidated,
        PutCursorBeforeEnd
    }
    public enum CompletionTriggerKind
    {
        Invoked = 1,
        TriggerCharacter,
        TriggerForIncompleteCompletions
    }
    public enum CompressionAlgorithm
    {
        Zstd = 0
    }
    public enum ComputerCameraMovementMode
    {
        Default = 0,
        Classic,
        Follow,
        Orbital,
        CameraToggle
    }
    public enum ComputerMovementMode
    {
        Default = 0,
        KeyboardMouse,
        ClickToMove
    }
    public enum ConfigSnapshotErrorState
    {
        None = 0,
        LoadFailed
    }
    public enum ConnectionError
    {
        OK = 0,
        Unknown,
        ConnectErrors,
        AlreadyConnected,
        NoFreeIncomingConnections,
        ConnectionBanned,
        InvalidPassword,
        IncompatibleProtocolVersion,
        IPRecentlyConnected,
        OurSystemRequiresSecurity,
        SecurityKeyMismatch,
        DisconnectErrors = 256,
        DisconnectBadhash,
        DisconnectSecurityKeyMismatch,
        DisconnectProtocolMismatch,
        DisconnectReceivePacketError,
        DisconnectReceivePacketStreamError,
        DisconnectSendPacketError,
        DisconnectIllegalTeleport,
        DisconnectDuplicatePlayer,
        DisconnectDuplicateTicket,
        DisconnectTimeout,
        DisconnectLuaKick,
        DisconnectOnRemoteSysStats,
        DisconnectHashTimeout,
        DisconnectCloudEditKick,
        DisconnectPlayerless,
        DisconnectNewSecurityKeyMismatch,
        DisconnectEvicted,
        DisconnectDevMaintenance,
        DisconnectRobloxMaintenance,
        DisconnectRejoin,
        DisconnectConnectionLost,
        DisconnectIdle,
        DisconnectRaknetErrors,
        DisconnectWrongVersion,
        DisconnectBySecurityPolicy,
        DisconnectBlockedIP,
        DisconnectClientFailure = 284,
        DisconnectClientRequest,
        DisconnectPrivateServerKickout,
        DisconnectModeratedGame,
        ServerShutdown,
        ReplicatorTimeout = 290,
        PlayerRemoved,
        DisconnectOutOfMemoryKeepPlayingLeave,
        DisconnectRomarkEndOfTest,
        DisconnectCollaboratorPermissionRevoked,
        DisconnectCollaboratorUnderage,
        NetworkInternal,
        NetworkSend,
        NetworkTimeout,
        NetworkMisbehavior,
        NetworkSecurity,
        ReplacementReady,
        ServerEmpty,
        PhantomFreeze,
        AndroidAnticheatKick,
        AndroidEmulatorKick,
        AndroidRootedKick,
        ScreentimeLockoutKick,
        DisconnectionNotification,
        DisconnectVerboselyModeratedGame,
        PlacelaunchErrors = 512,
        PlacelaunchDisabled = 515,
        PlacelaunchError,
        PlacelaunchGameEnded,
        PlacelaunchGameFull,
        PlacelaunchUserLeft = 522,
        PlacelaunchRestricted,
        PlacelaunchUnauthorized,
        PlacelaunchFlooded,
        PlacelaunchHashExpired,
        PlacelaunchHashException,
        PlacelaunchPartyCannotFit,
        PlacelaunchHttpError,
        PlacelaunchUserPrivacyUnauthorized = 533,
        PlacelaunchCreatorBan = 600,
        PlacelaunchCustomMessage = 610,
        PlacelaunchOtherError,
        TeleportErrors = 768,
        TeleportFailure,
        TeleportGameNotFound,
        TeleportGameEnded,
        TeleportGameFull,
        TeleportUnauthorized,
        TeleportFlooded,
        TeleportIsTeleporting
    }
    public enum ConnectionState
    {
        Connected = 0,
        Disconnected
    }
    public enum ContentSourceType
    {
        None = 0,
        Uri,
        Object,
        Opaque
    }
    public enum ContextActionPriority
    {
        Low = 1000,
        Medium = 2000,
        High = 3000
    }
    public enum ContextActionResult
    {
        Sink = 0,
        Pass
    }
    public enum ControlMode
    {
        Classic = 0,
        MouseLockSwitch
    }
    public enum CoreGuiType
    {
        PlayerList = 0,
        Health,
        Backpack,
        Chat,
        All,
        EmotesMenu,
        SelfView,
        Captures
    }
    public enum CreateAssetResult
    {
        Success = 1,
        PermissionDenied,
        UploadFailed,
        Unknown
    }
    public enum CreateOutfitFailure
    {
        InvalidName = 1,
        OutfitLimitReached,
        Other
    }
    public enum CreatorType
    {
        User = 0,
        Group
    }
    public enum CreatorTypeFilter
    {
        User = 0,
        Group,
        All
    }
    public enum CurrencyType
    {
        Default = 0,
        Robux,
        Tix
    }
    public enum CustomCameraMode
    {
        Default = 0,
        Classic,
        Follow
    }
    public enum DataStoreRequestType
    {
        GetAsync = 0,
        SetIncrementAsync,
        UpdateAsync,
        GetSortedAsync,
        SetIncrementSortedAsync,
        OnUpdate,
        ListAsync,
        GetVersionAsync,
        RemoveVersionAsync,
        StandardRead,
        StandardWrite,
        StandardList,
        StandardRemove,
        OrderedRead,
        OrderedWrite,
        OrderedList,
        OrderedRemove
    }
    public enum DebuggerEndReason
    {
        ClientRequest = 0,
        Timeout,
        InvalidHost,
        Disconnected,
        ServerShutdown,
        ServerProtocolMismatch,
        ConfigurationFailed,
        RpcError
    }
    public enum DebuggerExceptionBreakMode
    {
        Never = 0,
        Always,
        Unhandled
    }
    public enum DebuggerFrameType
    {
        C = 0,
        Lua
    }
    public enum DebuggerPauseReason
    {
        Unknown = 0,
        Requested,
        Breakpoint,
        Exception,
        SingleStep,
        Entrypoint
    }
    public enum DebuggerStatus
    {
        Success = 0,
        Timeout,
        ConnectionLost,
        InvalidResponse,
        InternalError,
        InvalidState,
        RpcError,
        InvalidArgument,
        ConnectionClosed
    }
    public enum DefaultScriptSyncFileType
    {
        Lua = 0,
        Luau
    }
    public enum DevCameraOcclusionMode
    {
        Zoom = 0,
        Invisicam
    }
    public enum DevComputerCameraMovementMode
    {
        UserChoice = 0,
        Classic,
        Follow,
        Orbital,
        CameraToggle
    }
    public enum DevComputerMovementMode
    {
        UserChoice = 0,
        KeyboardMouse,
        ClickToMove,
        Scriptable
    }
    public enum DevTouchCameraMovementMode
    {
        UserChoice = 0,
        Classic,
        Follow,
        Orbital
    }
    public enum DevTouchMovementMode
    {
        UserChoice = 0,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        Scriptable,
        DynamicThumbstick
    }
    public enum DeveloperMemoryTag
    {
        Internal = 0,
        HttpCache,
        Instances,
        Signals,
        LuaHeap,
        Script,
        PhysicsCollision,
        BaseParts,
        GraphicsSolidModels,
        GraphicsMeshParts = 10,
        GraphicsParticles,
        GraphicsParts,
        GraphicsSpatialHash,
        GraphicsTerrain,
        GraphicsTexture,
        GraphicsTextureCharacter,
        Sounds,
        StreamingSounds,
        TerrainVoxels,
        Gui = 21,
        Animation,
        Navigation,
        GeometryCSG,
        GraphicsSlimModels
    }
    public enum DeviceFeatureType
    {
        DeviceCapture = 0,
        InExperienceFAE
    }
    public enum DeviceForm
    {
        Console = 0,
        Phone,
        Tablet,
        Desktop,
        VR
    }
    public enum DeviceLevel
    {
        Low = 0,
        Medium,
        High
    }
    public enum DeviceType
    {
        Unknown = 0,
        Desktop,
        Tablet,
        Phone
    }
    public enum DialogBehaviorType
    {
        SinglePlayer = 0,
        MultiplePlayers
    }
    public enum DialogPurpose
    {
        Quest = 0,
        Help,
        Shop
    }
    public enum DialogTone
    {
        Neutral = 0,
        Friendly,
        Enemy
    }
    public enum DisplaySize
    {
        Small = 0,
        Medium,
        Large
    }
    public enum DominantAxis
    {
        Width = 0,
        Height
    }
    public enum DraftStatusCode
    {
        OK = 0,
        DraftOutdated,
        ScriptRemoved,
        DraftCommitted
    }
    public enum DragDetectorDragStyle
    {
        TranslateLine = 0,
        TranslatePlane,
        TranslatePlaneOrLine,
        TranslateLineOrPlane,
        TranslateViewPlane,
        RotateAxis,
        RotateTrackball,
        Scriptable,
        BestForDevice
    }
    public enum DragDetectorPermissionPolicy
    {
        Nobody = 0,
        Everybody,
        Scriptable
    }
    public enum DragDetectorResponseStyle
    {
        Geometric = 0,
        Physical,
        Custom
    }
    public enum DraggerCoordinateSpace
    {
        Object = 0,
        World
    }
    public enum DraggerMovementMode
    {
        Geometric = 0,
        Physical
    }
    public enum DraggingScrollBar
    {
        None = 0,
        Horizontal,
        Vertical
    }
    public enum EasingDirection
    {
        In = 0,
        Out,
        InOut
    }
    public enum EasingStyle
    {
        Linear = 0,
        Sine,
        Back,
        Quad,
        Quart,
        Quint,
        Bounce,
        Elastic,
        Exponential,
        Circular,
        Cubic
    }
    public enum EditableStatus
    {
        Unknown = 0,
        Allowed,
        Disallowed
    }
    public enum ElasticBehavior
    {
        WhenScrollable = 0,
        Always,
        Never
    }
    public enum EnviromentalPhysicsThrottle
    {
        DefaultAuto = 0,
        Disabled,
        Always,
        Skip2,
        Skip4,
        Skip8,
        Skip16
    }
    public enum ExperienceAuthScope
    {
        DefaultScope = 0,
        CreatorAssetsCreate
    }
    public enum ExperienceEventStatus
    {
        Active = 0,
        Cancelled,
        Moderated,
        Unpublished,
        Unknown
    }
    public enum ExperienceStateCaptureSelectionMode
    {
        Default = 0,
        SafetyHighlightMode
    }
    public enum ExperienceStateRecordingLoadMode
    {
        NewReplay = 0,
        ContiguousSlice,
        NoncontiguousSlice
    }
    public enum ExperienceStateRecordingLoadSourceType
    {
        S3Url = 0,
        File
    }
    public enum ExperienceStateRecordingPlaybackMode
    {
        Undefined = 0,
        Stopped,
        Playing,
        Rewinding
    }
    public enum ExplosionType
    {
        NoCraters = 0,
        Craters
    }
    public enum FACSDataLod
    {
        LOD0 = 0,
        LOD1,
        LODCount
    }
    public enum FacialAgeEstimationResultType
    {
        Complete = 0,
        Cancel,
        Error
    }
    public enum FacialAnimationStreamingState
    {
        None = 0,
        Audio,
        Video,
        Place = 4,
        Server = 8
    }
    public enum FacsActionUnit
    {
        ChinRaiserUpperLip = 0,
        ChinRaiser,
        FlatPucker,
        Funneler,
        LowerLipSuck,
        LipPresser,
        LipsTogether,
        MouthLeft,
        MouthRight,
        Pucker,
        UpperLipSuck,
        LeftCheekPuff,
        LeftDimpler,
        LeftLipCornerDown,
        LeftLowerLipDepressor,
        LeftLipCornerPuller,
        LeftLipStretcher,
        LeftUpperLipRaiser,
        RightCheekPuff,
        RightDimpler,
        RightLipCornerDown,
        RightLowerLipDepressor,
        RightLipCornerPuller,
        RightLipStretcher,
        RightUpperLipRaiser,
        JawDrop,
        JawLeft,
        JawRight,
        Corrugator,
        LeftBrowLowerer,
        LeftOuterBrowRaiser,
        LeftNoseWrinkler,
        LeftInnerBrowRaiser,
        RightBrowLowerer,
        RightOuterBrowRaiser,
        RightInnerBrowRaiser,
        RightNoseWrinkler,
        EyesLookDown,
        EyesLookLeft,
        EyesLookUp,
        EyesLookRight,
        LeftCheekRaiser,
        LeftEyeUpperLidRaiser,
        LeftEyeClosed,
        RightCheekRaiser,
        RightEyeUpperLidRaiser,
        RightEyeClosed,
        TongueDown,
        TongueOut,
        TongueUp
    }
    public enum FeatureRestrictionAbuseVector
    {
        ExperienceChat = 0,
        Communication
    }
    public enum FieldOfViewMode
    {
        Vertical = 0,
        Diagonal,
        MaxAxis
    }
    public enum FillDirection
    {
        Horizontal = 0,
        Vertical
    }
    public enum FilterErrorType
    {
        BackslashNotEscapingAnything = 0,
        BadBespokeFilter,
        BadName,
        IncompleteOr,
        IncompleteParenthesis,
        InvalidDoubleStar,
        InvalidTilde,
        PropertyBadOperator,
        PropertyDoesNotExist,
        PropertyInvalidField,
        PropertyInvalidValue,
        PropertyUnsupportedFields,
        PropertyUnsupportedProperty,
        UnexpectedNameIndex,
        UnexpectedToken,
        UnfinishedBinaryOperator,
        UnfinishedQuote,
        UnknownBespokeFilter,
        WildcardInProperty
    }
    public enum FilterResult
    {
        Accepted = 0,
        Rejected
    }
    public enum FinishRecordingOperation
    {
        Cancel = 0,
        Commit,
        Append
    }
    public enum FluidFidelity
    {
        Automatic = 0,
        UseCollisionGeometry,
        UsePreciseGeometry
    }
    public enum FluidForces
    {
        Default = 0,
        Experimental
    }
    public enum Font
    {
        Legacy = 0,
        Arial,
        ArialBold,
        SourceSans,
        SourceSansBold,
        SourceSansLight,
        SourceSansItalic,
        Bodoni,
        Garamond,
        Cartoon,
        Code,
        Highway,
        SciFi,
        Arcade,
        Fantasy,
        Antique,
        SourceSansSemibold,
        Gotham,
        GothamMedium,
        GothamBold,
        GothamBlack,
        AmaticSC,
        Bangers,
        Creepster,
        DenkOne,
        Fondamento,
        FredokaOne,
        GrenzeGotisch,
        IndieFlower,
        JosefinSans,
        Jura,
        Kalam,
        LuckiestGuy,
        Merriweather,
        Michroma,
        Nunito,
        Oswald,
        PatrickHand,
        PermanentMarker,
        Roboto,
        RobotoCondensed,
        RobotoMono,
        Sarpanch,
        SpecialElite,
        TitilliumWeb,
        Ubuntu,
        BuilderSans,
        BuilderSansMedium,
        BuilderSansBold,
        BuilderSansExtraBold,
        Arimo,
        ArimoBold,
        Unknown = 100
    }
    public enum FontSize
    {
        Size8 = 0,
        Size9,
        Size10,
        Size11,
        Size12,
        Size14,
        Size18,
        Size24,
        Size36,
        Size48,
        Size28,
        Size32,
        Size42,
        Size60,
        Size96
    }
    public enum FontStyle
    {
        Normal = 0,
        Italic
    }
    public enum FontWeight
    {
        Thin = 100,
        ExtraLight = 200,
        Light = 300,
        Regular = 400,
        Medium = 500,
        SemiBold = 600,
        Bold = 700,
        ExtraBold = 800,
        Heavy = 900
    }
    public enum ForceLimitMode
    {
        Magnitude = 0,
        PerAxis
    }
    public enum FormFactor
    {
        Symmetric = 0,
        Brick,
        Plate,
        Custom
    }
    public enum FrameStyle
    {
        Custom = 0,
        ChatBlue,
        RobloxSquare,
        RobloxRound,
        ChatGreen,
        ChatRed,
        DropShadow
    }
    public enum FramerateManagerMode
    {
        Automatic = 0,
        On,
        Off
    }
    public enum FriendRequestEvent
    {
        Issue = 0,
        Revoke,
        Accept,
        Deny
    }
    public enum FriendStatus
    {
        Unknown = 0,
        NotFriend,
        Friend,
        FriendRequestSent,
        FriendRequestReceived
    }
    public enum FunctionalTestResult
    {
        Passed = 0,
        Warning,
        Error
    }
    public enum GameAvatarType
    {
        R6 = 0,
        R15,
        PlayerChoice
    }
    public enum GamepadType
    {
        Unknown = 0,
        PS4,
        PS5,
        XboxOne
    }
    public enum GearGenreSetting
    {
        AllGenres = 0,
        MatchingGenreOnly
    }
    public enum GearType
    {
        MeleeWeapons = 0,
        RangedWeapons,
        Explosives,
        PowerUps,
        NavigationEnhancers,
        MusicalInstruments,
        SocialItems,
        BuildingTools,
        Transport
    }
    public enum Genre
    {
        All = 0,
        TownAndCity,
        Fantasy,
        SciFi,
        Ninja,
        Scary,
        Pirate,
        Adventure,
        Sports,
        Funny,
        WildWest,
        War,
        SkatePark,
        Tutorial
    }
    public enum GraphicsMode
    {
        Automatic = 1,
        Direct3D11,
        OpenGL = 4,
        Metal,
        Vulkan,
        NoGraphics = 9
    }
    public enum GraphicsOptimizationMode
    {
        Performance = 0,
        Balanced,
        Quality
    }
    public enum GroupMembershipStatus
    {
        None = 0,
        Joined,
        JoinRequestPending,
        AlreadyMember
    }
    public enum GuiState
    {
        Idle = 0,
        Hover,
        Press,
        NonInteractable
    }
    public enum GuiType
    {
        Core = 0,
        Custom,
        PlayerNameplates,
        CustomBillboards,
        CoreBillboards
    }
    public enum HandRigDescriptionSide
    {
        None = 0,
        Left,
        Right
    }
    public enum HandlesStyle
    {
        Resize = 0,
        Movement
    }
    public enum HapticEffectType
    {
        Custom = 0,
        UIHover,
        UIClick,
        UINotification,
        GameplayExplosion,
        GameplayCollision
    }
    public enum HashAlgorithm
    {
        Blake2b = 0,
        Blake3,
        Md5,
        Sha1,
        Sha256
    }
    public enum HighlightDepthMode
    {
        AlwaysOnTop = 0,
        Occluded
    }
    public enum HorizontalAlignment
    {
        Center = 0,
        Left,
        Right
    }
    public enum HoverAnimateSpeed
    {
        VerySlow = 0,
        Slow,
        Medium,
        Fast,
        VeryFast
    }
    public enum HttpCachePolicy
    {
        None = 0,
        Full,
        DataOnly,
        Default,
        InternalRedirectRefresh
    }
    public enum HttpCompression
    {
        None = 0,
        Gzip
    }
    public enum HttpContentType
    {
        ApplicationJson = 0,
        ApplicationXml,
        ApplicationUrlEncoded,
        TextPlain,
        TextXml
    }
    public enum HttpError
    {
        OK = 0,
        InvalidUrl,
        DnsResolve,
        ConnectFail,
        OutOfMemory,
        TimedOut,
        TooManyRedirects,
        InvalidRedirect,
        NetFail,
        Aborted,
        SslConnectFail,
        SslVerificationFail,
        Unknown,
        ConnectionClosed,
        ServerProtocolError,
        CreatorEnvironmentsNotSupportedByService
    }
    public enum HttpRequestType
    {
        Default = 0,
        MarketplaceService = 2,
        Players = 7,
        Chat = 15,
        Avatar,
        Analytics = 23,
        Localization = 25
    }
    public enum HumanoidCollisionType
    {
        OuterBox = 0,
        InnerBox
    }
    public enum HumanoidDisplayDistanceType
    {
        Viewer = 0,
        Subject,
        None
    }
    public enum HumanoidHealthDisplayType
    {
        DisplayWhenDamaged = 0,
        AlwaysOn,
        AlwaysOff
    }
    public enum HumanoidRigType
    {
        R6 = 0,
        R15
    }
    public enum HumanoidStateType
    {
        FallingDown = 0,
        Ragdoll,
        GettingUp,
        Jumping,
        Swimming,
        Freefall,
        Flying,
        Landed,
        Running,
        RunningNoPhysics = 10,
        StrafingNoPhysics,
        Climbing,
        Seated,
        PlatformStanding,
        Dead,
        Physics,
        None = 18
    }
    public enum IKCollisionsMode
    {
        NoCollisions = 0,
        OtherMechanismsAnchored,
        IncludeContactedMechanisms
    }
    public enum IKControlConstraintSupport
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum IKControlType
    {
        Transform = 0,
        Position,
        Rotation,
        LookAt
    }
    public enum IXPLoadingStatus
    {
        None = 0,
        Pending,
        Initialized,
        ErrorInvalidUser,
        ErrorConnection,
        ErrorJsonParse,
        ErrorTimedOut
    }
    public enum ImageAlphaType
    {
        Default = 1,
        LockCanvasAlpha,
        LockCanvasColor
    }
    public enum ImageCombineType
    {
        BlendSourceOver = 1,
        Overwrite,
        Add,
        Multiply,
        AlphaBlend
    }
    public enum InOut
    {
        Edge = 0,
        Inset,
        Center
    }
    public enum InfoType
    {
        Asset = 0,
        Product,
        GamePass,
        Subscription,
        Bundle
    }
    public enum InitialDockState
    {
        Top = 0,
        Bottom,
        Left,
        Right,
        Float
    }
    public enum InputActionType
    {
        Bool = 0,
        Direction1D,
        Direction2D,
        Direction3D,
        ViewportPosition
    }
    public enum InputType
    {
        NoInput = 0,
        Constant = 12,
        Sin
    }
    public enum IntermediateMeshGenerationResult
    {
        HighQualityMesh = 0
    }
    public enum InterpolationThrottlingMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum InviteState
    {
        Placed = 0,
        Accepted,
        Declined,
        Missed
    }
    public enum ItemLineAlignment
    {
        Automatic = 0,
        Start,
        Center,
        End,
        Stretch
    }
    public enum JoinSource
    {
        CreatedItemAttribution = 1
    }
    public enum JointCreationMode
    {
        All = 0,
        Surface,
        None
    }
    public enum KeyCode
    {
        Unknown = 0,
        Backspace = 8,
        Tab,
        Clear = 12,
        Return,
        Pause = 19,
        Escape = 27,
        Space = 32,
        QuotedDouble = 34,
        Hash,
        Dollar,
        Percent,
        Ampersand,
        Quote,
        LeftParenthesis,
        RightParenthesis,
        Asterisk,
        Plus,
        Comma,
        Minus,
        Period,
        Slash,
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Colon,
        Semicolon,
        LessThan,
        Equals,
        GreaterThan,
        Question,
        At,
        LeftBracket = 91,
        BackSlash,
        RightBracket,
        Caret,
        Underscore,
        Backquote,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        LeftCurly,
        Pipe,
        RightCurly,
        Tilde,
        Delete,
        KeypadZero = 256,
        KeypadOne,
        KeypadTwo,
        KeypadThree,
        KeypadFour,
        KeypadFive,
        KeypadSix,
        KeypadSeven,
        KeypadEight,
        KeypadNine,
        KeypadPeriod,
        KeypadDivide,
        KeypadMultiply,
        KeypadMinus,
        KeypadPlus,
        KeypadEnter,
        KeypadEquals,
        Up,
        Down,
        Right,
        Left,
        Insert,
        Home,
        End,
        PageUp,
        PageDown,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        F11,
        F12,
        F13,
        F14,
        F15,
        NumLock = 300,
        CapsLock,
        ScrollLock,
        RightShift,
        LeftShift,
        RightControl,
        LeftControl,
        RightAlt,
        LeftAlt,
        RightMeta,
        LeftMeta,
        LeftSuper,
        RightSuper,
        Mode,
        Compose,
        Help,
        Print,
        SysReq,
        Break,
        Menu,
        Power,
        Euro,
        Undo,
        ButtonX = 1000,
        ButtonY,
        ButtonA,
        ButtonB,
        ButtonR1,
        ButtonL1,
        ButtonR2,
        ButtonL2,
        ButtonR3,
        ButtonL3,
        ButtonStart,
        ButtonSelect,
        DPadLeft,
        DPadRight,
        DPadUp,
        DPadDown,
        Thumbstick1,
        Thumbstick2,
        Thumbstick1Up,
        Thumbstick1Down,
        Thumbstick1Left,
        Thumbstick1Right,
        Thumbstick2Up,
        Thumbstick2Down,
        Thumbstick2Left,
        Thumbstick2Right,
        MouseLeftButton,
        MouseRightButton,
        MouseMiddleButton,
        MousePosition = 1033,
        World0 = 160,
        World1,
        World2,
        World3,
        World4,
        World5,
        World6,
        World7,
        World8,
        World9,
        World10,
        World11,
        World12,
        World13,
        World14,
        World15,
        World16,
        World17,
        World18,
        World19,
        World20,
        World21,
        World22,
        World23,
        World24,
        World25,
        World26,
        World27,
        World28,
        World29,
        World30,
        World31,
        World32,
        World33,
        World34,
        World35,
        World36,
        World37,
        World38,
        World39,
        World40,
        World41,
        World42,
        World43,
        World44,
        World45,
        World46,
        World47,
        World48,
        World49,
        World50,
        World51,
        World52,
        World53,
        World54,
        World55,
        World56,
        World57,
        World58,
        World59,
        World60,
        World61,
        World62,
        World63,
        World64,
        World65,
        World66,
        World67,
        World68,
        World69,
        World70,
        World71,
        World72,
        World73,
        World74,
        World75,
        World76,
        World77,
        World78,
        World79,
        World80,
        World81,
        World82,
        World83,
        World84,
        World85,
        World86,
        World87,
        World88,
        World89,
        World90,
        World91,
        World92,
        World93,
        World94,
        World95,
        MouseBackButton = 1029,
        MouseNoButton,
        MouseX,
        MouseY
    }
    public enum KeyInterpolationMode
    {
        Constant = 0,
        Linear,
        Cubic
    }
    public enum KeywordFilterType
    {
        Include = 0,
        Exclude
    }
    public enum Language
    {
        Default = 0
    }
    public enum LeftRight
    {
        Left = 0,
        Center,
        Right
    }
    public enum LexemeType
    {
        Eof = 0,
        Name,
        QuotedString,
        Number,
        And,
        Or,
        Equal,
        TildeEqual,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual,
        Colon,
        Dot,
        LeftParenthesis,
        RightParenthesis,
        Star,
        DoubleStar,
        ReservedSpecial
    }
    public enum LightingStyle
    {
        Realistic = 0,
        Soft
    }
    public enum Limb
    {
        Head = 0,
        Torso,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
        Unknown
    }
    public enum LineJoinMode
    {
        Round = 0,
        Bevel,
        Miter
    }
    public enum ListDisplayMode
    {
        Horizontal = 0,
        Vertical
    }
    public enum ListenerLocation
    {
        Default = 0,
        None,
        Character,
        Camera
    }
    public enum ListenerType
    {
        Camera = 0,
        CFrame,
        ObjectPosition,
        ObjectCFrame
    }
    public enum LiveEditingAtomicUpdateResponse
    {
        Success = 0,
        FailureGuidNotFound,
        FailureHashMismatch,
        FailureOperationIllegal
    }
    public enum LiveEditingBroadcastMessageType
    {
        Normal = 0,
        Warning,
        Error
    }
    public enum LoadCharacterLayeredClothing
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum LoadDynamicHeads
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum LocationType
    {
        Character = 0,
        Camera,
        ObjectPosition
    }
    public enum LuauTypeCheckMode
    {
        Default = 0,
        NoCheck,
        Nonstrict,
        Strict
    }
    public enum MarketplaceBulkPurchasePromptStatus
    {
        Completed = 1,
        Aborted,
        Error
    }
    public enum MarketplaceItemPurchaseStatus
    {
        Success = 1,
        SystemError,
        AlreadyOwned,
        InsufficientRobux,
        QuantityLimitExceeded,
        QuotaExceeded,
        NotForSale,
        NotAvailableForPurchaser,
        PriceMismatch,
        SoldOut,
        PurchaserIsSeller,
        InsufficientMembership,
        PlaceInvalid
    }
    public enum MarketplaceProductType
    {
        AvatarAsset = 1,
        AvatarBundle
    }
    public enum MarkupKind
    {
        PlainText = 0,
        Markdown
    }
    public enum MatchmakingType
    {
        Default = 1,
        XboxOnly,
        PlayStationOnly
    }
    public enum Material
    {
        Plastic = 256,
        SmoothPlastic = 272,
        Neon = 288,
        Wood = 512,
        WoodPlanks = 528,
        Marble = 784,
        Slate = 800,
        Concrete = 816,
        Granite = 832,
        Brick = 848,
        Pebble = 864,
        Cobblestone = 880,
        Rock = 896,
        Sandstone = 912,
        Basalt = 788,
        CrackedLava = 804,
        Limestone = 820,
        Pavement = 836,
        CorrodedMetal = 1040,
        DiamondPlate = 1056,
        Foil = 1072,
        Metal = 1088,
        Grass = 1280,
        LeafyGrass = 1284,
        Sand = 1296,
        Fabric = 1312,
        Snow = 1328,
        Mud = 1344,
        Ground = 1360,
        Asphalt = 1376,
        Salt = 1392,
        Ice = 1536,
        Glacier = 1552,
        Glass = 1568,
        ForceField = 1584,
        Air = 1792,
        Water = 2048,
        Cardboard = 2304,
        Carpet,
        CeramicTiles,
        ClayRoofTiles,
        RoofShingles,
        Leather,
        Plaster,
        Rubber
    }
    public enum MaterialPattern
    {
        Regular = 0,
        Organic
    }
    public enum MembershipType
    {
        None = 0,
        BuildersClub,
        TurboBuildersClub,
        OutrageousBuildersClub,
        Premium
    }
    public enum MeshPartDetailLevel
    {
        DistanceBased = 0,
        Level00,
        Level01,
        Level02,
        Level03,
        Level04
    }
    public enum MeshPartHeadsAndAccessories
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum MeshScaleUnit
    {
        Stud = 0,
        Meter,
        CM,
        MM,
        Foot,
        Inch
    }
    public enum MeshType
    {
        Head = 0,
        Torso,
        Wedge,
        Sphere,
        Cylinder,
        FileMesh,
        Brick,
        Prism,
        Pyramid,
        ParallelRamp,
        RightAngleRamp,
        CornerWedge
    }
    public enum MessageType
    {
        MessageOutput = 0,
        MessageInfo,
        MessageWarning,
        MessageError
    }
    public enum ModelLevelOfDetail
    {
        Automatic = 0,
        StreamingMesh,
        Disabled,
        SLIM = 4
    }
    public enum ModelStreamingBehavior
    {
        Default = 0,
        Legacy,
        Improved
    }
    public enum ModelStreamingMode
    {
        Default = 0,
        Atomic,
        Persistent,
        PersistentPerPlayer,
        Nonatomic
    }
    public enum ModerationResultCategory
    {
        ViolationDetected = 0,
        Borderline,
        NoViolationDetected
    }
    public enum ModerationResultLabel
    {
        ChildExploitation = 0,
        SuicideSelfInjuryAndHarmfulBehavior,
        ThreatsBullyingAndHarassment,
        TerrorismAndViolentExtremism,
        DiscriminationSlursAndHateSpeech,
        RealWorldSensitiveEvents,
        ViolentContentAndGore,
        RomanticAndSexualContent,
        IllegalAndRegulatedGoodsAndActivities,
        Profanity,
        Other = 100
    }
    public enum ModerationStatus
    {
        ReviewedApproved = 1,
        ReviewedRejected,
        NotReviewed,
        NotApplicable,
        Invalid
    }
    public enum ModifierKey
    {
        Shift = 0,
        Ctrl,
        Alt,
        Meta
    }
    public enum MouseBehavior
    {
        Default = 0,
        LockCenter,
        LockCurrentPosition
    }
    public enum MoveState
    {
        Stopped = 0,
        Coasting,
        Pushing,
        Stopping,
        AirFree
    }
    public enum MoverConstraintRootBehaviorMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum MuteState
    {
        Unmuted = 0,
        Muted
    }
    public enum NameOcclusion
    {
        NoOcclusion = 0,
        EnemyOcclusion,
        OccludeAll
    }
    public enum NegateOperationHiddenHistory
    {
        None = 0,
        NegatedUnion,
        NegatedIntersection
    }
    public enum NetworkOwnership
    {
        Automatic = 0,
        Manual,
        OnContact
    }
    public enum NetworkStatus
    {
        Unknown = 0,
        Connected,
        Disconnected
    }
    public enum NoiseType
    {
        SimplexGabor = 0
    }
    public enum NormalId
    {
        Right = 0,
        Top,
        Back,
        Left,
        Bottom,
        Front
    }
    public enum NotificationButtonType
    {
        Primary = 0,
        Secondary
    }
    public enum OperationType
    {
        Null = 0,
        Union,
        Subtraction,
        Intersection,
        Primitive
    }
    public enum OrientationAlignmentMode
    {
        OneAttachment = 0,
        TwoAttachment
    }
    public enum OutfitSource
    {
        All = 1,
        Created,
        Purchased
    }
    public enum OutfitType
    {
        All = 1,
        Avatar,
        DynamicHead,
        Shoes
    }
    public enum OutputLayoutMode
    {
        Horizontal = 0,
        Vertical
    }
    public enum OverrideMouseIconBehavior
    {
        None = 0,
        ForceShow,
        ForceHide
    }
    public enum PackagePermission
    {
        None = 0,
        NoAccess,
        Revoked,
        UseView,
        Edit,
        Own
    }
    public enum PartType
    {
        Ball = 0,
        Block,
        Cylinder,
        Wedge,
        CornerWedge
    }
    public enum ParticleEmitterShape
    {
        Box = 0,
        Sphere,
        Cylinder,
        Disc
    }
    public enum ParticleEmitterShapeInOut
    {
        Outward = 0,
        Inward,
        InAndOut
    }
    public enum ParticleEmitterShapeStyle
    {
        Volume = 0,
        Surface
    }
    public enum ParticleFlipbookLayout
    {
        None = 0,
        Grid2x2,
        Grid4x4,
        Grid8x8,
        Custom
    }
    public enum ParticleFlipbookMode
    {
        Loop = 0,
        OneShot,
        PingPong,
        Random
    }
    public enum ParticleFlipbookTextureCompatible
    {
        NotCompatible = 0,
        Compatible,
        Unknown
    }
    public enum ParticleOrientation
    {
        FacingCamera = 0,
        FacingCameraWorldUp,
        VelocityParallel,
        VelocityPerpendicular
    }
    public enum PathStatus
    {
        Success = 0,
        NoPath = 5,
        ClosestNoPath = 1,
        ClosestOutOfRange,
        FailStartNotEmpty,
        FailFinishNotEmpty
    }
    public enum PathWaypointAction
    {
        Walk = 0,
        Jump,
        Custom
    }
    public enum PathfindingUseImprovedSearch
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum PeoplePageLayout
    {
        Card = 0,
        List
    }
    public enum PerformanceOverlayMode
    {
        Overdraw = 0,
        Transparent,
        Decals,
        Lights
    }
    public enum PermissionLevelShown
    {
        Game = 0,
        RobloxGame,
        RobloxScript,
        Studio,
        Roblox
    }
    public enum PhysicsSimulationRate
    {
        Fixed240Hz = 0,
        Fixed120Hz,
        Fixed60Hz
    }
    public enum PhysicsSteppingMethod
    {
        Default = 0,
        Fixed,
        Adaptive
    }
    public enum PlaceContentPreference
    {
        None = 0,
        All,
        MentionsAndReplies,
        Unknown
    }
    public enum PlacePublishType
    {
        None = 0,
        Publish,
        Save
    }
    public enum Platform
    {
        Windows = 0,
        OSX,
        IOS,
        Android,
        XBoxOne,
        PS4,
        PS3,
        XBox360,
        WiiU,
        NX,
        Ouya,
        AndroidTV,
        Chromecast,
        Linux,
        SteamOS,
        WebOS,
        DOS,
        BeOS,
        UWP,
        PS5,
        MetaOS,
        None
    }
    public enum PlaybackState
    {
        Begin = 0,
        Delayed,
        Playing,
        Paused,
        Completed,
        Cancelled
    }
    public enum PlayerActions
    {
        CharacterForward = 0,
        CharacterBackward,
        CharacterLeft,
        CharacterRight,
        CharacterJump
    }
    public enum PlayerCharacterDestroyBehavior
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum PlayerChatType
    {
        All = 0,
        Team,
        Whisper
    }
    public enum PlayerDataErrorState
    {
        LoadFailed = 0,
        FlushFailed,
        ReleaseFailed,
        None
    }
    public enum PlayerDataLoadFailureBehavior
    {
        Failure = 0,
        FallbackToDefault,
        Kick
    }
    public enum PlayerExitReason
    {
        Unknown = 0,
        PlatformKick,
        CreatorKick
    }
    public enum PoseEasingDirection
    {
        In = 0,
        Out,
        InOut
    }
    public enum PoseEasingStyle
    {
        Linear = 0,
        Constant,
        Elastic,
        Cubic,
        Bounce,
        CubicV2
    }
    public enum PositionAlignmentMode
    {
        OneAttachment = 0,
        TwoAttachment
    }
    public enum PredictionMode
    {
        Automatic = 0,
        On,
        Off
    }
    public enum PredictionStatus
    {
        Authoritative = 0,
        Predicted,
        None
    }
    public enum PreferredInput
    {
        KeyboardAndMouse = 0,
        Gamepad,
        Touch
    }
    public enum PreferredTextSize
    {
        Medium = 1,
        Large,
        Larger,
        Largest
    }
    public enum PrimalPhysicsSolver
    {
        Default = 0,
        Experimental,
        Disabled
    }
    public enum PrimitiveType
    {
        Null = 0,
        Ball,
        Cylinder,
        Block,
        Wedge,
        CornerWedge
    }
    public enum PrivilegeType
    {
        Owner = 255,
        Admin = 240,
        Member = 128,
        Visitor = 10,
        Banned = 0
    }
    public enum ProductLocationRestriction
    {
        AvatarShop = 0,
        AllowedGames,
        AllGames
    }
    public enum ProductPurchaseChannel
    {
        InExperience = 1,
        ExperienceDetailsPage,
        AdReward,
        CommerceProduct
    }
    public enum ProductPurchaseDecision
    {
        NotProcessedYet = 0,
        PurchaseGranted
    }
    public enum PromptCreateAssetResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        UnknownFailure,
        UGCValidationFailed,
        ModeratedName,
        PurchaseFailure,
        TokenInvalid
    }
    public enum PromptCreateAvatarResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        InvalidHumanoidDescription,
        UGCValidationFailed,
        ModeratedName,
        MaxOutfits,
        PurchaseFailure,
        UnknownFailure,
        TokenInvalid
    }
    public enum PromptExperienceDetailsResult
    {
        PromptClosed = 0,
        TeleportAttempted
    }
    public enum PromptLinkSharingResult
    {
        Success = 1,
        PlayerLeft,
        InvalidLaunchData
    }
    public enum PromptPublishAssetResult
    {
        Success = 1,
        PermissionDenied,
        Timeout,
        UploadFailed,
        NoUserInput,
        UnknownFailure
    }
    public enum PropertyStatus
    {
        Ok = 0,
        Warning,
        Error
    }
    public enum ProximityPromptExclusivity
    {
        OnePerButton = 0,
        OneGlobally,
        AlwaysShow
    }
    public enum ProximityPromptInputType
    {
        Keyboard = 0,
        Gamepad,
        Touch
    }
    public enum ProximityPromptStyle
    {
        Default = 0,
        Custom
    }
    public enum QualityLevel
    {
        Automatic = 0,
        Level01,
        Level02,
        Level03,
        Level04,
        Level05,
        Level06,
        Level07,
        Level08,
        Level09,
        Level10,
        Level11,
        Level12,
        Level13,
        Level14,
        Level15,
        Level16,
        Level17,
        Level18,
        Level19,
        Level20,
        Level21
    }
    public enum R15CollisionType
    {
        OuterBox = 0,
        InnerBox
    }
    public enum RaycastFilterType
    {
        Exclude = 0,
        Include
    }
    public enum ReadCapturesFromGalleryResult
    {
        Success = 0,
        NeedPermission
    }
    public enum RecommendationActionType
    {
        AddReaction = 0,
        RemoveReaction,
        Share,
        Report,
        Comment,
        Play,
        Purchase
    }
    public enum RecommendationDepartureIntent
    {
        Neutral = 0,
        Positive,
        Negative
    }
    public enum RecommendationImpressionType
    {
        View = 0,
        NotViewable
    }
    public enum RecommendationItemContentType
    {
        Static = 0,
        Dynamic,
        Interactive
    }
    public enum RecommendationItemVisibility
    {
        Private = 0,
        Public
    }
    public enum RejectCharacterDeletions
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum RenderFidelity
    {
        Automatic = 0,
        Precise,
        Performance
    }
    public enum RenderPriority
    {
        First = 0,
        Input = 100,
        Camera = 200,
        Character = 300,
        Last = 2000
    }
    public enum RenderingCacheOptimizationMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum RenderingTestComparisonMethod
    {
        psnr = 0,
        diff
    }
    public enum ReplicateInstanceDestroySetting
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum ResamplerMode
    {
        Default = 0,
        Pixelated
    }
    public enum ReservedHighlightId
    {
        Standard = 0,
        Selection = 524288,
        Hover = 262144,
        Active = 131072
    }
    public enum RestPose
    {
        Default = 0,
        RotationsReset,
        Custom
    }
    public enum ReturnKeyType
    {
        Default = 0,
        Done,
        Go,
        Next,
        Search,
        Send
    }
    public enum ReverbType
    {
        NoReverb = 0,
        GenericReverb,
        PaddedCell,
        Room,
        Bathroom,
        LivingRoom,
        StoneRoom,
        Auditorium,
        ConcertHall,
        Cave,
        Arena,
        Hangar,
        CarpettedHallway,
        Hallway,
        StoneCorridor,
        Alley,
        Forest,
        City,
        Mountains,
        Quarry,
        Plain,
        ParkingLot,
        SewerPipe,
        UnderWater
    }
    public enum ReviewableContentState
    {
        Pending = 0,
        Completed,
        Failed
    }
    public enum RibbonTool
    {
        Select = 0,
        Scale,
        Rotate,
        Move,
        Transform,
        ColorPicker,
        MaterialPicker,
        Group,
        Ungroup,
        None,
        PivotEditor
    }
    public enum RigScale
    {
        Default = 0,
        Rthro,
        RthroNarrow
    }
    public enum RigType
    {
        R15 = 0,
        CustomHumanoid,
        Custom,
        None
    }
    public enum RollOffMode
    {
        Inverse = 0,
        Linear,
        LinearSquare,
        InverseTapered
    }
    public enum RolloutState
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum RotationOrder
    {
        XYZ = 0,
        XZY,
        YZX,
        YXZ,
        ZXY,
        ZYX
    }
    public enum RotationType
    {
        MovementRelative = 0,
        CameraRelative
    }
    public enum RsvpStatus
    {
        None = 0,
        Going,
        NotGoing
    }
    public enum RtlTextSupport
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum RunContext
    {
        Legacy = 0,
        Server,
        Client,
        Plugin
    }
    public enum RunState
    {
        Stopped = 0,
        Running,
        Paused
    }
    public enum RuntimeUndoBehavior
    {
        Aggregate = 0,
        Snapshot,
        Hybrid
    }
    public enum SafeAreaCompatibility
    {
        None = 0,
        FullscreenExtension
    }
    public enum SalesTypeFilter
    {
        All = 1,
        Collectibles,
        Premium,
        TimedOptions
    }
    public enum SandboxedInstanceMode
    {
        Default = 0,
        Experimental
    }
    public enum SaveAvatarThumbnailCustomizationFailure
    {
        BadThumbnailType = 1,
        BadYRotDeg,
        BadFieldOfViewDeg,
        BadDistanceScale,
        Other,
        Throttled
    }
    public enum SaveFilter
    {
        SaveWorld = 0,
        SaveGame,
        SaveAll
    }
    public enum SavedQualitySetting
    {
        Automatic = 0,
        QualityLevel1,
        QualityLevel2,
        QualityLevel3,
        QualityLevel4,
        QualityLevel5,
        QualityLevel6,
        QualityLevel7,
        QualityLevel8,
        QualityLevel9,
        QualityLevel10
    }
    public enum ScaleType
    {
        Stretch = 0,
        Slice,
        Tile,
        Fit,
        Crop
    }
    public enum ScopeCheckResult
    {
        ConsentAccepted = 0,
        InvalidScopes,
        Timeout,
        NoUserInput,
        BackendError,
        UnexpectedError,
        InvalidArgument,
        ConsentDenied
    }
    public enum ScreenInsets
    {
        None = 0,
        DeviceSafeInsets,
        CoreUISafeInsets,
        TopbarSafeInsets
    }
    public enum ScreenOrientation
    {
        LandscapeLeft = 0,
        LandscapeRight,
        LandscapeSensor,
        Portrait,
        Sensor
    }
    public enum ScrollBarInset
    {
        None = 0,
        ScrollBar,
        Always
    }
    public enum ScrollingDirection
    {
        X = 1,
        Y,
        XY = 4
    }
    public enum SecurityCapability
    {
        RunClientScript = 0,
        RunServerScript,
        AccessOutsideWrite,
        AssetRequire,
        LoadString,
        ScriptGlobals,
        CreateInstances,
        Basic,
        Audio,
        DataStore,
        Network,
        Physics,
        UI,
        CSG,
        Chat,
        Animation,
        Avatar,
        Input,
        Environment,
        RemoteEvent,
        LegacySound,
        Players,
        CapabilityControl,
        Plugin,
        LocalUser,
        WritePlayer,
        RobloxScript,
        RobloxEngine,
        Unassigned,
        InternalTest,
        PluginOrOpenCloud,
        Assistant,
        RemoteCommand
    }
    public enum SelectionBehavior
    {
        Escape = 0,
        Stop
    }
    public enum SelectionRenderMode
    {
        Outlines = 0,
        BoundingBoxes,
        Both
    }
    public enum SelfViewPosition
    {
        LastPosition = 0,
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
    public enum SensorMode
    {
        Floor = 0,
        Ladder
    }
    public enum SensorUpdateType
    {
        OnRead = 0,
        Manual
    }
    public enum ServerLiveEditingMode
    {
        Uninitialized = 0,
        Enabled,
        Disabled
    }
    public enum ServiceVisibility
    {
        Always = 0,
        Off,
        WithChildren
    }
    public enum Severity
    {
        Error = 1,
        Warning,
        Information,
        Hint
    }
    public enum ShowAdResult
    {
        ShowCompleted = 1,
        AdNotReady,
        AdAlreadyShowing,
        InternalError,
        ShowInterrupted,
        InsufficientMemory
    }
    public enum SignalBehavior
    {
        Default = 0,
        Immediate,
        Deferred,
        AncestryDeferred
    }
    public enum SizeConstraint
    {
        RelativeXY = 0,
        RelativeXX,
        RelativeYY
    }
    public enum SolverConvergenceMetricType
    {
        IterationBased = 0,
        AlgorithmAgnostic
    }
    public enum SolverConvergenceVisualizationMode
    {
        Disabled = 0,
        PerIsland,
        PerEdge
    }
    public enum SortDirection
    {
        Ascending = 0,
        Descending
    }
    public enum SortOrder
    {
        Name = 0,
        Custom,
        LayoutOrder
    }
    public enum SpecialKey
    {
        Insert = 0,
        Home,
        End,
        PageUp,
        PageDown,
        ChatHotkey
    }
    public enum StartCorner
    {
        TopLeft = 0,
        TopRight,
        BottomLeft,
        BottomRight
    }
    public enum StateObjectFieldType
    {
        Boolean = 0,
        CFrame,
        Color3,
        Float,
        Instance,
        Random,
        Vector2,
        Vector3,
        INVALID
    }
    public enum Status
    {
        Poison = 0,
        Confusion
    }
    public enum StepFrequency
    {
        Hz60 = 0,
        Hz30,
        Hz15,
        Hz10,
        Hz5,
        Hz1
    }
    public enum StreamOutBehavior
    {
        Default = 0,
        LowMemory,
        Opportunistic
    }
    public enum StreamingIntegrityMode
    {
        Default = 0,
        Disabled,
        MinimumRadiusPause,
        PauseOutsideLoadedArea
    }
    public enum StreamingPauseMode
    {
        Default = 0,
        Disabled,
        ClientPhysicsPause
    }
    public enum StrokeSizingMode
    {
        FixedSize = 0,
        ScaledSize
    }
    public enum StudioCloseMode
    {
        None = 0,
        CloseStudio,
        CloseDoc,
        LogOut
    }
    public enum StudioDataModelType
    {
        Edit = 0,
        PlayClient,
        PlayServer,
        Standalone,
        None
    }
    public enum StudioPlaceUpdateFailureReason
    {
        Other = 0,
        TeamCreateConflict
    }
    public enum StudioScriptEditorColorCategories
    {
        Default = 0,
        Operator,
        Number,
        String,
        Comment,
        Keyword,
        Builtin,
        Method,
        Property,
        Nil,
        Bool,
        Function,
        Local,
        Self,
        LuauKeyword,
        FunctionName,
        TODO,
        Background,
        SelectionText,
        SelectionBackground,
        FindSelectionBackground,
        MatchingWordBackground,
        Warning,
        Error,
        Info,
        Hint,
        Whitespace,
        ActiveLine,
        DebuggerCurrentLine,
        DebuggerErrorLine,
        Ruler,
        Bracket,
        Type,
        MenuPrimaryText,
        MenuSecondaryText,
        MenuSelectedText,
        MenuBackground,
        MenuSelectedBackground,
        MenuScrollbarBackground,
        MenuScrollbarHandle,
        MenuBorder,
        DocViewCodeBackground,
        AICOOverlayText,
        AICOOverlayButtonBackground,
        AICOOverlayButtonBackgroundHover,
        AICOOverlayButtonBackgroundPressed,
        IndentationRuler
    }
    public enum StudioScriptEditorColorPresets
    {
        RobloxDefault = 0,
        Extra1,
        Extra2,
        Custom
    }
    public enum StudioStyleGuideColor
    {
        MainBackground = 0,
        Titlebar,
        Dropdown,
        Tooltip,
        Notification,
        ScrollBar,
        ScrollBarBackground,
        TabBar,
        Tab,
        FilterButtonDefault,
        FilterButtonHover,
        FilterButtonChecked,
        FilterButtonAccent,
        FilterButtonBorder,
        FilterButtonBorderAlt,
        RibbonTab,
        RibbonTabTopBar,
        Button,
        MainButton,
        RibbonButton,
        ViewPortBackground,
        InputFieldBackground,
        Item,
        TableItem,
        CategoryItem,
        GameSettingsTableItem,
        GameSettingsTooltip,
        EmulatorBar,
        EmulatorDropDown,
        ColorPickerFrame,
        CurrentMarker,
        Border,
        DropShadow,
        Shadow,
        Light,
        Dark,
        Mid,
        MainText,
        SubText,
        TitlebarText,
        BrightText,
        DimmedText,
        LinkText,
        WarningText,
        ErrorText,
        InfoText,
        SensitiveText,
        ScriptSideWidget,
        ScriptBackground,
        ScriptText,
        ScriptSelectionText,
        ScriptSelectionBackground,
        ScriptFindSelectionBackground,
        ScriptMatchingWordSelectionBackground,
        ScriptOperator,
        ScriptNumber,
        ScriptString,
        ScriptComment,
        ScriptKeyword,
        ScriptBuiltInFunction,
        ScriptWarning,
        ScriptError,
        ScriptInformation,
        ScriptHint,
        ScriptWhitespace,
        ScriptRuler,
        DocViewCodeBackground,
        DebuggerCurrentLine,
        DebuggerErrorLine,
        DiffFilePathText,
        DiffTextHunkInfo,
        DiffTextNoChange,
        DiffTextAddition,
        DiffTextDeletion,
        DiffTextSeparatorBackground,
        DiffTextNoChangeBackground,
        DiffTextAdditionBackground,
        DiffTextDeletionBackground,
        DiffLineNum,
        DiffLineNumSeparatorBackground,
        DiffLineNumNoChangeBackground,
        DiffLineNumAdditionBackground,
        DiffLineNumDeletionBackground,
        DiffFilePathBackground,
        DiffFilePathBorder,
        ChatIncomingBgColor,
        ChatIncomingTextColor,
        ChatOutgoingBgColor,
        ChatOutgoingTextColor,
        ChatModeratedMessageColor,
        Separator,
        ButtonBorder,
        ButtonText,
        InputFieldBorder,
        CheckedFieldBackground,
        CheckedFieldBorder,
        CheckedFieldIndicator,
        HeaderSection,
        Midlight,
        StatusBar,
        DialogButton,
        DialogButtonText,
        DialogButtonBorder,
        DialogMainButton,
        DialogMainButtonText,
        InfoBarWarningBackground,
        InfoBarWarningText,
        ScriptEditorCurrentLine,
        ScriptMethod,
        ScriptProperty,
        ScriptNil,
        ScriptBool,
        ScriptFunction,
        ScriptLocal,
        ScriptSelf,
        ScriptLuauKeyword,
        ScriptFunctionName,
        ScriptTodo,
        ScriptBracket,
        AttributeCog,
        AICOOverlayText = 128,
        AICOOverlayButtonBackground,
        AICOOverlayButtonBackgroundHover,
        AICOOverlayButtonBackgroundPressed,
        OnboardingCover,
        OnboardingHighlight,
        OnboardingShadow,
        BreakpointMarker = 136,
        DiffLineNumHover,
        DiffLineNumSeparatorBackgroundHover
    }
    public enum StudioStyleGuideModifier
    {
        Default = 0,
        Selected,
        Pressed,
        Disabled,
        Hover
    }
    public enum Style
    {
        AlternatingSupports = 0,
        BridgeStyleSupports,
        NoSupports
    }
    public enum SubscriptionExpirationReason
    {
        ProductInactive = 0,
        ProductDeleted,
        SubscriberCancelled,
        SubscriberRefunded,
        Lapsed
    }
    public enum SubscriptionPaymentStatus
    {
        Paid = 0,
        Refunded
    }
    public enum SubscriptionPeriod
    {
        Month = 0
    }
    public enum SubscriptionState
    {
        NeverSubscribed = 0,
        SubscribedWillRenew,
        SubscribedWillNotRenew,
        SubscribedRenewalPaymentPending,
        Expired
    }
    public enum SurfaceConstraint
    {
        None = 0,
        Hinge,
        SteppingMotor,
        Motor
    }
    public enum SurfaceGuiShape
    {
        Flat = 0,
        CurvedHorizontally
    }
    public enum SurfaceGuiSizingMode
    {
        FixedSize = 0,
        PixelsPerStud
    }
    public enum SurfaceType
    {
        Smooth = 0,
        Glue,
        Weld,
        Studs,
        Inlet,
        Universal,
        Hinge,
        Motor,
        SteppingMotor,
        SmoothNoOutlines = 10
    }
    public enum SwipeDirection
    {
        Right = 0,
        Left,
        Up,
        Down,
        None
    }
    public enum SystemThemeValue
    {
        error = 0,
        light,
        dark,
        systemLight,
        systemDark
    }
    public enum TableMajorAxis
    {
        RowMajor = 0,
        ColumnMajor
    }
    public enum TeamCreateErrorState
    {
        PlaceSizeTooLarge = 0,
        PlaceSizeApproachingLimit,
        PlaceUploadFailing,
        NoError
    }
    public enum Technology
    {
        Voxel = 1,
        Compatibility,
        ShadowMap,
        Future,
        Legacy = 0,
        Unified = 5
    }
    public enum TelemetryBackend
    {
        UNSPECIFIED = 0,
        EventIngest,
        Points,
        Teletune,
        EphemeralCounter,
        EphemeralStat,
        Counter,
        Stat
    }
    public enum TelemetryStandardizedField
    {
        AddDatacenterId = 0,
        AddPlaceId,
        AddUniverseId,
        AddPlaceInstanceId,
        AddPlaySessionId,
        AddCurrentContextName,
        AddOsInfo,
        AddArchitectureInfo,
        AddCpuInfo,
        AddMemoryInfo,
        AddSessionInfo
    }
    public enum TeleportMethod
    {
        TeleportToSpawnByName = 0,
        TeleportToPlaceInstance,
        TeleportToPrivateServer,
        TeleportPartyAsync,
        TeleportToVIPServer,
        TeleportToInstanceBack,
        TeleportUnknown
    }
    public enum TeleportResult
    {
        Success = 0,
        Failure,
        GameNotFound,
        GameEnded,
        GameFull,
        Unauthorized,
        Flooded,
        IsTeleporting
    }
    public enum TeleportState
    {
        RequestedFromServer = 0,
        Started,
        WaitingForServer,
        Failed,
        InProgress
    }
    public enum TeleportType
    {
        ToPlace = 0,
        ToInstance,
        ToReservedServer,
        ToVIPServer,
        ToInstanceBack
    }
    public enum TerrainAcquisitionMethod
    {
        None = 0,
        Legacy,
        Template,
        Generate,
        Import,
        Convert,
        EditAddTool,
        EditSeaLevelTool,
        EditReplaceTool,
        RegionFillTool,
        RegionPasteTool,
        Other
    }
    public enum TerrainFace
    {
        Top = 0,
        Side,
        Bottom
    }
    public enum TextChatMessageStatus
    {
        Unknown = 1,
        Success,
        Sending,
        TextFilterFailed,
        Floodchecked,
        InvalidPrivacySettings,
        InvalidTextChannelPermissions,
        MessageTooLong,
        ModerationTimeout
    }
    public enum TextDirection
    {
        Auto = 0,
        LeftToRight,
        RightToLeft
    }
    public enum TextFilterContext
    {
        PublicChat = 1,
        PrivateChat
    }
    public enum TextInputType
    {
        Default = 0,
        NoSuggestions,
        Number,
        Email,
        Phone,
        Password,
        PasswordShown,
        Username,
        OneTimePassword
    }
    public enum TextTruncate
    {
        None = 0,
        AtEnd,
        SplitWord
    }
    public enum TextXAlignment
    {
        Left = 0,
        Right,
        Center
    }
    public enum TextYAlignment
    {
        Top = 0,
        Center,
        Bottom
    }
    public enum TextureMode
    {
        Stretch = 0,
        Wrap,
        Static
    }
    public enum TextureQueryType
    {
        NonHumanoid = 0,
        NonHumanoidOrphaned,
        Humanoid,
        HumanoidOrphaned
    }
    public enum ThreadPoolConfig
    {
        PerCore4 = 104,
        PerCore3 = 103,
        PerCore2 = 102,
        PerCore1 = 101,
        Auto = 0,
        Threads1,
        Threads2,
        Threads3,
        Threads4,
        Threads8 = 8,
        Threads16 = 16
    }
    public enum ThrottlingPriority
    {
        Extreme = 2,
        ElevatedOnServer = 1,
        Default = 0
    }
    public enum ThumbnailSize
    {
        Size48x48 = 0,
        Size180x180,
        Size420x420,
        Size60x60,
        Size100x100,
        Size150x150,
        Size352x352
    }
    public enum ThumbnailType
    {
        HeadShot = 0,
        AvatarBust,
        AvatarThumbnail
    }
    public enum TickCountSampleMethod
    {
        Fast = 0,
        Benchmark,
        Precise
    }
    public enum TonemapperPreset
    {
        Default = 0,
        Retro
    }
    public enum TopBottom
    {
        Top = 0,
        Center,
        Bottom
    }
    public enum TouchCameraMovementMode
    {
        Default = 0,
        Classic,
        Follow,
        Orbital
    }
    public enum TouchMovementMode
    {
        Default = 0,
        Thumbstick,
        DPad,
        Thumbpad,
        ClickToMove,
        DynamicThumbstick
    }
    public enum TrackerError
    {
        Ok = 0,
        NoService,
        InitFailed,
        NoVideo,
        VideoError,
        VideoNoPermission,
        VideoUnsupported,
        NoAudio,
        AudioError,
        AudioNoPermission,
        UnsupportedDevice
    }
    public enum TrackerExtrapolationFlagMode
    {
        Auto = 3,
        ForceDisabled = 0,
        ExtrapolateFacsAndPose,
        ExtrapolateFacsOnly
    }
    public enum TrackerFaceTrackingStatus
    {
        FaceTrackingSuccess = 0,
        FaceTrackingNoFaceFound,
        FaceTrackingUnknown,
        FaceTrackingLost,
        FaceTrackingHasTrackingError,
        FaceTrackingIsOccluded,
        FaceTrackingUninitialized
    }
    public enum TrackerLodFlagMode
    {
        Auto = 2,
        ForceFalse = 0,
        ForceTrue
    }
    public enum TrackerLodValueMode
    {
        Auto = 2,
        Force0 = 0,
        Force1
    }
    public enum TrackerMode
    {
        None = 0,
        Audio,
        Video,
        AudioVideo
    }
    public enum TrackerPromptEvent
    {
        LODCameraRecommendDisable = 0
    }
    public enum TrackerType
    {
        None = 0,
        Face,
        UpperBody
    }
    public enum TriStateBoolean
    {
        False = 2,
        True = 1,
        Unknown = 0
    }
    public enum TweenStatus
    {
        Canceled = 0,
        Completed
    }
    public enum UICaptureMode
    {
        All = 0,
        None
    }
    public enum UIDragDetectorBoundingBehavior
    {
        Automatic = 0,
        EntireObject,
        HitPoint
    }
    public enum UIDragDetectorDragRelativity
    {
        Absolute = 0,
        Relative
    }
    public enum UIDragDetectorDragSpace
    {
        Parent = 0,
        LayerCollector,
        Reference
    }
    public enum UIDragDetectorDragStyle
    {
        TranslatePlane = 0,
        TranslateLine,
        Rotate,
        Scriptable
    }
    public enum UIDragDetectorResponseStyle
    {
        Offset = 0,
        Scale,
        CustomOffset,
        CustomScale
    }
    public enum UIDragSpeedAxisMapping
    {
        XY = 0,
        XX,
        YY
    }
    public enum UIFlexAlignment
    {
        None = 0,
        Fill,
        SpaceAround,
        SpaceBetween,
        SpaceEvenly
    }
    public enum UIFlexMode
    {
        None = 0,
        Grow,
        Shrink,
        Fill,
        Custom
    }
    public enum UITheme
    {
        Light = 0,
        Dark
    }
    public enum UiMessageType
    {
        UiMessageError = 0,
        UiMessageInfo
    }
    public enum UpdateState
    {
        UpdateNotAvailable = 0,
        UpdateAvailable,
        UpdateInProgress,
        UpdateReady,
        UpdateFailed
    }
    public enum UploadCaptureResult
    {
        Success = 0,
        NeedPermission,
        CaptureModerated,
        CaptureNotInGallery,
        IneligibleCapture,
        UploadQuotaReached
    }
    public enum UsageContext
    {
        Default = 0,
        Preview
    }
    public enum UserCFrame
    {
        Head = 0,
        LeftHand,
        RightHand,
        Floor
    }
    public enum UserInputState
    {
        Begin = 0,
        Change,
        End,
        Cancel,
        None
    }
    public enum UserInputType
    {
        MouseButton1 = 0,
        MouseButton2,
        MouseButton3,
        MouseWheel,
        MouseMovement,
        Touch = 7,
        Keyboard,
        Focus,
        Accelerometer,
        Gyro,
        Gamepad1,
        Gamepad2,
        Gamepad3,
        Gamepad4,
        Gamepad5,
        Gamepad6,
        Gamepad7,
        Gamepad8,
        TextInput,
        InputMethod,
        None
    }
    public enum VRComfortSetting
    {
        Comfort = 0,
        Normal,
        Expert,
        Custom
    }
    public enum VRControllerModelMode
    {
        Disabled = 0,
        Transparent
    }
    public enum VRDeviceType
    {
        Unknown = 0,
        OculusRift,
        HTCVive,
        ValveIndex,
        OculusQuest
    }
    public enum VRLaserPointerMode
    {
        Disabled = 0,
        Pointer,
        DualPointer
    }
    public enum VRSafetyBubbleMode
    {
        NoOne = 0,
        OnlyFriends,
        Anyone
    }
    public enum VRScaling
    {
        World = 0,
        Off
    }
    public enum VRSessionState
    {
        Undefined = 0,
        Idle,
        Visible,
        Focused,
        Stopping
    }
    public enum VRTouchpad
    {
        Left = 0,
        Right
    }
    public enum VRTouchpadMode
    {
        Touch = 0,
        VirtualThumbstick,
        ABXY
    }
    public enum VelocityConstraintMode
    {
        Line = 0,
        Plane,
        Vector
    }
    public enum VerticalAlignment
    {
        Center = 0,
        Top,
        Bottom
    }
    public enum VerticalScrollBarPosition
    {
        Right = 0,
        Left
    }
    public enum VibrationMotor
    {
        Large = 0,
        Small,
        LeftTrigger,
        RightTrigger,
        LeftHand,
        RightHand
    }
    public enum VideoCaptureResult
    {
        Success = 0,
        OtherError,
        ScreenSizeChanged,
        TimeLimitReached
    }
    public enum VideoCaptureStartedResult
    {
        Success = 0,
        OtherError,
        CapturingAlready,
        NoDeviceSupport,
        NoSpaceOnDevice
    }
    public enum VideoDeviceCaptureQuality
    {
        Default = 0,
        Low,
        Medium,
        High
    }
    public enum VideoError
    {
        Ok = 0,
        Eof,
        EAgain,
        BadParameter,
        AllocFailed,
        CodecInitFailed,
        CodecCloseFailed,
        DecodeFailed,
        ParsingFailed,
        Unsupported,
        Generic,
        DownloadFailed,
        StreamNotFound,
        EncodeFailed,
        CreateFailed,
        NoPermission,
        NoService,
        ReleaseFailed,
        Unknown
    }
    public enum VideoSampleSize
    {
        Small = 0,
        Medium,
        Large,
        Full
    }
    public enum ViewMode
    {
        None = 0,
        GeometryComplexity,
        Transparent,
        Decal
    }
    public enum VirtualCursorMode
    {
        Default = 0,
        Disabled,
        Enabled
    }
    public enum VirtualInputMode
    {
        None = 0,
        Recording,
        Playing
    }
    public enum VoiceChatDistanceAttenuationType
    {
        Inverse = 0,
        Legacy
    }
    public enum VoiceChatState
    {
        Idle = 0,
        Joining,
        JoiningRetry,
        Joined,
        Leaving,
        Ended,
        Failed
    }
    public enum VoiceClientLeaveReasons
    {
        Unknown = 0,
        ClientNetworkDisconnected,
        PlayerLeft,
        ClientShutdown,
        PublishFailed,
        RejoinReceived,
        VoiceReboot,
        ImguiDebugLeave,
        LuaInitiated
    }
    public enum VoiceControlPath
    {
        Publish = 0,
        Subscribe,
        Join
    }
    public enum VolumetricAudio
    {
        Disabled = 0,
        Automatic,
        Enabled
    }
    public enum WaterDirection
    {
        NegX = 0,
        X,
        NegY,
        Y,
        NegZ,
        Z
    }
    public enum WaterForce
    {
        None = 0,
        Small,
        Medium,
        Strong,
        Max
    }
    public enum WebSocketState
    {
        Connecting = 0,
        Open,
        Closing,
        Closed
    }
    public enum WebStreamClientState
    {
        Connecting = 0,
        Open,
        Error,
        Closed
    }
    public enum WebStreamClientType
    {
        SSE = 0,
        RawStream,
        WebSocket
    }
    public enum WeldConstraintPreserve
    {
        All = 0,
        None,
        Touching
    }
    public enum WhisperChatPrivacyMode
    {
        AllUsers = 0,
        NoOne
    }
    public enum WrapLayerAutoSkin
    {
        Disabled = 0,
        EnabledPreserve,
        EnabledOverride
    }
    public enum WrapLayerDebugMode
    {
        None = 0,
        BoundCage,
        LayerCage,
        BoundCageAndLinks,
        Reference,
        Rbf,
        OuterCage,
        ReferenceMeshAfterMorph,
        HSROuterDetail,
        HSROuter,
        HSRInner,
        HSRInnerReverse,
        LayerCageFittedToBase,
        LayerCageFittedToPrev,
        PreWrapDeformerOuterCage
    }
    public enum WrapTargetDebugMode
    {
        None = 0,
        TargetCageOriginal,
        TargetCageCompressed,
        TargetCageInterface,
        TargetLayerCageOriginal,
        TargetLayerCageCompressed,
        TargetLayerInterface,
        Rbf,
        OuterCageDetail,
        PreWrapDeformerCage
    }
    public enum ZIndexBehavior
    {
        Global = 0,
        Sibling
    }
}