import * as fs from "fs";
import {
  flow,
  split,
  sum,
  map,
  parseInt,
  head,
  take,
  reverse,
} from "lodash/fp";
import { sortBy } from "lodash";
import { getInput } from "../helpers/retrieveInput";

const sumBlock = flow(split("\n"), map(parseInt(10)), sum);
const totalsPerBlock = flow(split("\n\n"), map(sumBlock), sortBy, reverse);

const part1 = flow(totalsPerBlock, head);
const part2 = flow(totalsPerBlock, take(3), sum);

const solve = async () => {
  const file = await getInput(1);
  console.log(part1(file), part2(file));
};

solve();
