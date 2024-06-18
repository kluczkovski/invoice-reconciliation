const path = require('path');
const glob = require('glob');

// Paths
const parentDir = "..";
const outputPath = path.resolve(__dirname, parentDir, parentDir, "wwwroot", "js");

// Plugins
const TsconfigPathsPlugin = require('tsconfig-paths-webpack-plugin');

function getEntryFiles(){
    const fileList = glob.sync("./Assets/TypeScript/entry/*.ts");
    const entryFiles = {};

    console.log(fileList);
    fileList.forEach(filepath => {
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
                test: /\.tsx?$/,
                use: [{
                    loader: "ts-loader",
                }],
            }
        ],
    },
    output: {
        path: outputPath,
        clean: true
    },
    performance: {
        hints: "warning",
    },
    resolve: {
        extensions: [".ts", ".tsx", ".js"],
        plugins: [
            new  TsconfigPathsPlugin()
        ],
        preferRelative: true
    }
};

module.exports = config;