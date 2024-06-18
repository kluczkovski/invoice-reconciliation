const path = require("path");
const glob = require("glob");

// Paths
const parentDir = "..";
const publicPath = path.resolve(__dirname, parentDir, parentDir, "wwwroot");
const cssPath = path.resolve(publicPath, "css");

console.log(publicPath);

// Plugins
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const NodeSassGlobImporter = require("node-sass-glob-importer");
const RemoveEmptyScriptsPlugin = require("webpack-remove-empty-scripts");

function getEntryFiles() {
    const fileList = glob.sync("./Assets/Sass/entry/*.scss");
    const entryFiles = {};

    console.log(fileList);
    fileList.forEach((filepath) => {
        const filename = path.basename(filepath, path.extname(filepath));

        entryFiles[filename] = filepath;
    });

    return entryFiles;
}

const config = {
    entry: getEntryFiles(),
    module: {
        rules: [
            {
                test: /\.(sa|sc|c)ss$/,
                use: [
                    { loader: MiniCssExtractPlugin.loader },
                    {
                        loader: "css-loader",
                        options: {
                            url: false
                        }
                    },
                    {
                        loader: "postcss-loader",
                        options: {
                            postcssOptions: {
                                plugins: [
                                    "postcss-preset-env",
                                ]
                            }
                        }
                    },
                    {
                        loader: "sass-loader",
                        options: {
                            sassOptions: {
                                importer: NodeSassGlobImporter()
                            }
                        }
                    }
                ]
            }
        ],
    },
    output: {
        path: cssPath,
        clean: true
    },
    performance: {
        hints: "warning",
    },
    plugins: [
        new RemoveEmptyScriptsPlugin(),
        new MiniCssExtractPlugin()
    ],
    resolve: {
        preferRelative: true,
        roots: [
            publicPath
        ],
    }
};

module.exports = config;