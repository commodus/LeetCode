package com.company;

import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {

    public static void main(String[] args) {
	    int[] nums = {-1, -2, -3};
	    maximumProduct(nums);
    }

    public static int maximumProduct(int[] nums) {
        int max1 = Integer.MIN_VALUE, max2 = Integer.MIN_VALUE, max3 = Integer.MIN_VALUE;
        int min1 = Integer.MAX_VALUE, min2 = Integer.MAX_VALUE;
        for (int num : nums){
            if(num > max1){
                max3 = max2;
                max2 = max1;
                max1 = num;
            }
            else if (num > max2){
                max3 = max2;
                max2 = num;
            }
            else if (num > max3)
                max3 = num;
            if(num < min1){
                min2 = min1;
                min1 = num;
            }
            else if (num < min2)
                min2 = num;
        }
        return Math.max(max1 * max2 * max3, max1 * min1 * min2);
    }

    public static int maximumProduct_sort(int[] nums) {
        Arrays.sort(nums);
        int max1 = nums[nums.length - 1], max2 = nums[nums.length - 2], max3 = nums[nums.length - 3];
        int min1 = nums[0], min2 = nums[1];
        return Math.max(max1 * max2 * max3, max1 * min1 * min2);
    }
}
