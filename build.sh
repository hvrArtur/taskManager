#!/bin/bash

SOLUTION="TaskManager.slnx"
CONFIGURATION="Debug"
LOG_FILE="build.log"
VERBOSITY="min"

while [[ $# -gt 0 ]]; do
    case $1 in
        -S|--solution)
            SOLUTION="$2"
            shift 2
            ;;
        -C|--configuration)
            CONFIGURATION="$2"
            shift 2
            ;;
        -LF|--log-file)
            LOG_FILE="$2"
            shift 2
            ;;
        -V|--verbosity)
            VERBOSITY="$2"
            shift 2
            ;;
        *)
            echo "Unknown option: $1"
            exit 1
            ;;
    esac
done


REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"


export DOTNET_CLI_HOME="${DOTNET_CLI_HOME:-$REPO_ROOT/.dotnet}"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE="${DOTNET_SKIP_FIRST_TIME_EXPERIENCE:-1}"

mkdir -p "$DOTNET_CLI_HOME"

case $VERBOSITY in
    min)
        MSBUILD_VERBOSITY="minimal"
        ;;
    norm)
        MSBUILD_VERBOSITY="normal"
        ;;
    diag)
        MSBUILD_VERBOSITY="diagnostic"
        ;;
    *)
        echo "Invalid verbosity: $VERBOSITY (use: min, norm, diag)"
        exit 1
        ;;
esac

dotnet build "$SOLUTION" \
    -c "$CONFIGURATION" \
    -m:1 \
    -v:"$MSBUILD_VERBOSITY" > "$LOG_FILE" 2>&1

BUILD_EXIT_CODE=$?

if [ $BUILD_EXIT_CODE -ne 0 ]; then
    echo "Build failed. See $LOG_FILE" >&2
    exit $BUILD_EXIT_CODE
else
    echo "Build succeeded. Verbosity: $VERBOSITY. Log: $LOG_FILE"
fi
