package com.company.P126.WordLadderII;

import java.util.HashSet;
import java.util.Set;

import static org.junit.Assert.*;

/**
 * Created by kayang on 6/10/2015.
 */
public class SolutionTest {

    @org.junit.Test
    public void testFindLadders() throws Exception {
        String start = "a";
        String end = "c";
        Set<String> dict = new HashSet<String>();
        dict.add("a");
        dict.add("b");
        dict.add("c");
        new Solution().findLadders(start, end, dict);
    }
}