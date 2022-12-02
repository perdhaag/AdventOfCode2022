import * as fs from "fs";
import path from "path";
import axios from "axios";
import { trim } from "lodash";
require("dotenv").config();

const fetchInput = async (dayNumber: number) => {
  const content = await axios.get(
    `https://adventofcode.com/2022/day/${dayNumber}/input`,
    {
      headers: {
        "user-agent": process.env.USER_AGENT,
        cookie: `session=${process.env.SESSION}` ?? "",
      },
    }
  );
  const data = trim(content.data);
  fs.writeFileSync(
    path.resolve(__dirname, `../day${dayNumber}/input.txt`),
    data
  );
  return data;
};

export const getInput = async (dayNumber: number) => {
  try {
    return fs
      .readFileSync(path.resolve(__dirname, `../day${dayNumber}/input.txt`))
      .toString();
  } catch {
    return fetchInput(dayNumber);
  }
};
