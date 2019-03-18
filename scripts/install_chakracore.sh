#!/usr/bin/env bash


echo '---------------------------'
echo `pwd`
path=(pwd)
echo $path
if [ -d "./ChakraCoreFiless" ]; then
    echo 'file have ...ChakraCoreFiles'
    echo 'file have ...ChakraCoreFiles'
else
    echo 'file no...'
    echo 'wget https://aka.ms/chakracore/cc_linux_x64_1_11_1'
    wget https://aka.ms/chakracore/cc_linux_x64_1_11_1
    echo 'tar xf cc_linux_x64_1_11_1'
    tar xf cc_linux_x64_1_11_1
fi
echo 'ls ChakraCoreFiles/*'
ls ChakraCoreFiles/*
echo '---------------------------'
ls

echo '-------------------'
echo './ChakraCoreFiles/bin/ch -?'
./ChakraCoreFiles/bin/ch -?
echo '-------------------'
echo ' ./ChakraCoreFiles/bin/ch --version'
 ./ChakraCoreFiles/bin/ch --version


FILE_NAME="ChakraCore.dll"
TO_FILE=$1${FILE_NAME}
FROM_FILE=

if [[ -f "$TO_FILE" ]]; then
    echo "$TO_FILE exists, no need to download again"
    exit
fi

GET_OS()
{
    UNAME_OUTPUT=$(uname -mrsn)

    if [[ "${UNAME_OUTPUT}" =~ 'Darwin' ]]; then
        CURRENT_OS="macOS"
        FROM_FILE="libChakraCore.dylib"
        return
    fi

    if [[ "${UNAME_OUTPUT}" =~ 'Linux' ]]; then
        CURRENT_OS="Linux"
        FROM_FILE="libChakraCore.so"
        return
    fi

    exit
}

GET_OS

WORK_PATH=`pwd`
SCRIPTS_PATH=$(cd "$(dirname "$0")";pwd)
DOWNLOAD_PATH=${SCRIPTS_PATH}/.tmp/chakracore

CHAKRACORE_FILE=${DOWNLOAD_PATH}/ChakraCoreFiles/lib/${FROM_FILE}

if [[ ! -f "$CHAKRACORE_FILE" ]]; then
    rm -rf ${DOWNLOAD_PATH} && mkdir -p ${DOWNLOAD_PATH}
    cd ${DOWNLOAD_PATH}
    bash ${SCRIPTS_PATH}/download_chakracore.sh 1_11_1
fi

cd ${WORK_PATH}
cp ${CHAKRACORE_FILE} ${TO_FILE}
