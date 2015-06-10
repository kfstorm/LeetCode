package com.company.P126.WordLadderII;

import java.util.*;

public class Solution {
    public List<List<String>> findLadders(String start, String end, Set<String> dict) {
        List<List<String>> stringResults = new ArrayList<List<String>>();
        if (start == end) {
            ArrayList<String> result = new ArrayList<String>();
            result.add(start);
            stringResults.add(result);
            return stringResults;
        }

        dict.remove(start);
        dict.remove(end);

        ArrayList<String> newDict = new ArrayList<String>(dict);
        newDict.add(start);
        newDict.add(end);

        ArrayList<Set<Integer>> paths = new ArrayList<Set<Integer>>();
        for (int i = 0; i < newDict.size(); ++i) {
            paths.add(new HashSet<Integer>());
        }
        for (int i = 0; i < start.length(); ++i) {
            HashMap<String, ArrayList<Integer>> tempDict = new HashMap<String, ArrayList<Integer>>();
            for (int j = 0; j < newDict.size(); ++j) {
                String original = newDict.get(j);
                String modified = original.substring(0, i) + "_" + original.substring(i + 1);
                ArrayList<Integer> same;
                if (tempDict.containsKey(modified)) {
                    same = tempDict.get(modified);
                } else {
                    same = new ArrayList<Integer>();
                    tempDict.put(modified, same);
                }
                for (int another : same) {
                    paths.get(another).add(j);
                    paths.get(j).add(another);
                }
                same.add(j);
            }
        }

        ArrayList<ArrayList<ArrayList<Integer>>> queue = new ArrayList<ArrayList<ArrayList<Integer>>>();
        boolean[] mark = new boolean[newDict.size()];
        int foundStep = -1;
        int foundIndex = -1;

        ArrayList<Integer> startNode = new ArrayList<Integer>();
        startNode.add(newDict.size() - 1);
        ArrayList<ArrayList<Integer>> startStep = new ArrayList<ArrayList<Integer>>();
        startStep.add(startNode);
        queue.add(startStep);
        mark[newDict.size() - 1] = true;

        for (int i = 0; i < queue.size() && foundStep == -1; ++i) {
            HashMap<Integer, ArrayList<Integer>> toBeAdded = new HashMap<Integer, ArrayList<Integer>>();
            ArrayList<ArrayList<Integer>> currentStep = queue.get(i);
            ArrayList<ArrayList<Integer>> nextStep = new ArrayList<ArrayList<Integer>>();
            for (int j = 0; j < currentStep.size(); ++j) {
                ArrayList<Integer> currentNode = currentStep.get(j);
                Set<Integer> path = paths.get(currentNode.get(0));
                for (int nextIndex : path) {
                    if (mark[nextIndex]) continue;
                    if (!toBeAdded.containsKey(nextIndex)) {
                        ArrayList<Integer> newNode = new ArrayList<Integer>();
                        newNode.add(nextIndex);
                        newNode.add(j);
                        nextStep.add(newNode);
                        if (nextIndex == newDict.size() - 2 && foundStep == -1) {
                            foundStep = i + 1;
                            foundIndex = nextStep.size() - 1;
                        }
                        toBeAdded.put(nextIndex, newNode);
                    } else {
                        toBeAdded.get(nextIndex).add(j);
                    }
                }
            }

            for (Map.Entry<Integer, ArrayList<Integer>> entry : toBeAdded.entrySet()) {
                mark[entry.getKey()] = true;
            }
            if (nextStep.size() > 0) {
                queue.add(nextStep);
            }
        }

        if (foundStep == -1) {
            return stringResults;
        }

        ArrayList<String> str = new ArrayList<String>();
        GenerateResults(stringResults, queue, newDict, str, queue.get(foundStep).get(foundIndex), foundStep);
        return stringResults;
    }

    private void GenerateResults(List<List<String>> stringResults, ArrayList<ArrayList<ArrayList<Integer>>> queue, ArrayList<String> newDict, ArrayList<String> str, ArrayList<Integer> currentNode, int step) {
        str.add(newDict.get(currentNode.get(0)));
        if (step == 0) {
            stringResults.add(new ArrayList<String>(str));
        } else {
            for (int i = 1; i < currentNode.size(); ++i) {
                GenerateResults(stringResults, queue, newDict, str, queue.get(step - 1).get(currentNode.get(i)), step - 1);
            }
        }
        str.remove(str.size() - 1);
    }
}