import * as fs from "fs";
import {
  flow,
  split,
  sum,
  toString,
  map,
  parseInt,
  head,
  take,
  reverse,
} from "lodash/fp";
import { sortBy } from "lodash";
import * as path from "path";

const file = fs.readFileSync(path.resolve(__dirname, "./input.txt")).toString();
