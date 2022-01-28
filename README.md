# Simple backend for storage and modification of images
## Authentication
The only required authentication is email address, in case no such address exists in database, a new user is created
## Image storage
Images are stored on disk, original image in images/source and each subseqent transform in images/output
As such it ensures safety of uploaded file
## Meta Data
There are 2 types of metadata:
- ImageInfo which represents uploaded image
- Transform which corresponds to particular filter application on image
## Example of request
User uploads image -> original image is stored in source, and empty transform (with no filters applied) is stored in output\
User reqeusts change -> original image is treated as baseline, composition of filters is then applied, and resulting image is saved\
Older version of the same image are detected and subsequently removed
## Launching
Backend uses mysql as db, as such it requires runing instance of it in background, it may be best to run migration beforehand\
Sql dump is also stored in MySql directory
You can also launch them both by typing `docker-compose up --build`, but program lanunched in such
way has cors issues with imager frontend, so it's only userful for testing api with postman
