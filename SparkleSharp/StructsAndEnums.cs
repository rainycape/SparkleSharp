namespace SparkleSharp
{
    public enum SUError
    {
	    AppcastParseError = 1000,
	    NoUpdateError = 1001,
	    AppcastError = 1002,
	    RunningFromDiskImageError = 1003,

	    TemporaryDirectoryError = 2000,
		SUDownloadError = 2001,

		UnarchivingError = 3000,
	    SignatureError = 3001,

	    FileCopyFailure = 4000,
	    AuthenticationFailure = 4001,
	    MissingUpdateError = 4002,
	    MissingInstallerToolError = 4003,
	    RelaunchError = 4004,
	    InstallationError = 4005,
	    DowngradeError = 4006,
		SUInstallationCancelledError = 4007,

		SystemPowerOffError = 5000
    };
}
