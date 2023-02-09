const { createServer } = require('https');
const { parse } = require('url');
const { readFileSync } = require('fs');
const next = require('next');
const path = require('path');

const port = 3000;
const dev = process.env.NODE_ENV !== 'production';
const app = next({ dev });
const handle = app.getRequestHandler();

const baseFolder =
	process.env.APPDATA !== undefined && process.env.APPDATA !== ''
		? `${process.env.APPDATA}/ASP.NET/https`
		: `${process.env.HOME}/.aspnet/https`;

const certificateArg = process.argv
	.map((arg) => arg.match(/--name=(?<value>.+)/i))
	.filter(Boolean)[0];
const certificateName = certificateArg ? certificateArg.groups.value : process.env.npm_package_name;

if (!certificateName) {
	console.error(
		'Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly.'
	);
	process.exit(-1);
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`);
const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

const httpsOptions = {
	key: readFileSync(keyFilePath),
	cert: readFileSync(certFilePath),
};

app.prepare().then(() => {
	createServer(httpsOptions, (req, res) => {
		const parsedUrl = parse(req.url, true);
		handle(req, res, parsedUrl);
	}).listen(port, (err) => {
		if (err) throw err;
		console.log(`> Ready on https://localhost:${port}`);
	});
});
