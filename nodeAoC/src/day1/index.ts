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

const sumBlock = flow(split("\n"), map(parseInt(10)), sum);

const totalsPerBlock = flow(split("\n\n"), map(sumBlock), sortBy, reverse);

const part1 = flow(totalsPerBlock, head);
const part2 = flow(totalsPerBlock, take(3), sum);

console.log(part1(file), part2(file));
