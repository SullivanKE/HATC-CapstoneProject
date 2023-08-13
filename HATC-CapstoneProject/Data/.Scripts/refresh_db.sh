#!/bin/bash

dotnet ef migrations add update_$(uuidgen)

echo "migration add command exited with $($?)"

if [ $? == 0 ]
then
    echo "updating database ..."
    dotnet ef database update
    if [ $? == 0 ] 
    then
	echo "database updated successfully"
	exit 0
    fi
fi
echo "something went wrong, exited with $($?)
exit $?


