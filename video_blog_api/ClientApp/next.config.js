/** @type {import('next').NextConfig} */
const nextConfig = {
	reactStrictMode: true,
	swcMinify: true,
	async rewrites() {
		return [
			{
				source: '/:path*',
				destination: 'http://localhost:5240/:path*',
			},
		];
	},
};

module.exports = nextConfig;
