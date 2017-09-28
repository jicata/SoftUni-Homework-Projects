const url = require('url');
const fs = require('fs');
const path = require('path');

function getContentType(resourcePath) {
    let fileExtension = resourcePath.split('.').pop();
    console.log(fileExtension);
    switch (fileExtension) {
        case 'ico':
            return 'image/x-icon';
        case 'css':
            return 'text/css';
        case 'js':
            return 'application/x-javascript';
        case 'png',
             'jpg':
            return 'image/png';
    }
}

module.exports = (req, res) => {
    req.pathname = req.pathname || url.parse(req.url).pathname;
    if (req.pathname.startsWith('/content/') && req.method === 'GET') {
        let filePath = path.normalize(
            path.join(__dirname, `..${req.pathname}`));
        fs.readFile(filePath, (err, data) => {
            if (err) {
                console.log(err);
                res.writeHead(404, {
                    'Content-Type': 'text/plain'
                });

                res.write('404 not found');
                res.end();
                return;
            }

            res.writeHead(200, {
                'Content-Type': getContentType(filePath)
            });

            res.write(data);
            res.end;
        })
    } else {
        return true;
    }

}