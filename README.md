# GettrDl

This is a simple command line tool to yoink videos from gettr.com.<br>
expect this to break at any moment as i am blatantly poking at the api with no guarantee that it will stay this way

# Usage

download the version appropriate for your system in [releases](https://github.com/RinLovesYou/gettrdl/releases/latest)<br>
run it in cmd like `gettrdl https://gettr.com/post/id` and it will download it to the folder it's running in.

# How

if you really care how it works here's a really simple explanation

Gettr.com posts have a url like `gettr.com/post/[id]`. <br>
Looking through network sources while the browser loads the page shows that a request to `api.gettr.com/u/post/[id]/[...]/` is being made.<br>
So making a request to `api.gettr.com/post/[id]` returns some nice json data, including a direct link to the mp4 file attached to the post.<br>
through poking around XHR data i found that `media.gettr.com` hosts these videos, and the json file includes an "ovid" property with the value that completes this url.<br>

so my program makes 2 requests, once to the api to query the mp4 location, and once to the media url to download the file.
