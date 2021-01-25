const path = require("path");
const CopyPlugin = require("copy-webpack-plugin");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: "./src/site.ts",
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "js/site.[chunkhash].js",
        publicPath: "/"
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            },
            {
                test: /\.css$/,
                use: [MiniCssExtractPlugin.loader, "css-loader"]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: "css/[name].[chunkhash].css"
        }),
        new CopyPlugin([
            { 
                from: "node_modules/bootstrap/dist/css/bootstrap.css", 
                to: "css"
            },
            {
                from: "node_modules/bootstrap/dist/js/bootstrap.js",
                to: "js"
            }
        ])
    ]
};