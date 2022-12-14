#!/bin/bash

#URL="https://www.gitignore.io/api/nonexistentlanguage"

URL="https://my-json-server.typicode.com/typicode/demo/posts"
response=$(curl -s -w "%{http_code}" $URL)

http_code=$(tail -n1 <<< "$response")  # get the last line
content=$(sed '$ d' <<< "$response")   # get all but the last line which contains the status code

echo "$http_code"
echo "$content"


$(content)| jq '.title'

$content| grep -iq '"[title]"'

#grep -Po '"title":.*?[^\\]",' $content

#https://unix.stackexchange.com/questions/572424/retrieve-both-http-status-code-and-content-from-curl-in-a-shell-script
#https://devhints.io/bash
#https://stackoverflow.com/questions/1955505/parsing-json-with-unix-tools
#https://medium.com/how-tos-for-coders/https-medium-com-how-tos-for-coders-parse-json-data-using-jq-and-curl-from-command-line-5aa8a05cd79b
#https://www.putorius.net/grep-curl-output.html