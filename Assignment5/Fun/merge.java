import java.util.Arrays;

class merge {
    public static void main(String args[]) {
        int[] ls1 = {1,2,4};       
        int[] ls2 = {3,5,7};  

        var temp = merge(ls1,ls2);
        System.out.println(Arrays.toString(temp));
    }

    private static int[] merge(int[] ls1, int[] ls2) {
        int p = 0;
        int[] auxArr = new int[ls1.length+ls2.length];
        for (int i = 0 ; i < ls1.length ; i++) {
            auxArr[p] = ls1[i];
            p++;
        }
        for (int i = 0 ; i < ls2.length ; i++) {
            auxArr[p] = ls2[i];
            p++;
        }

        Arrays.sort(auxArr);
    
        return auxArr;
    }
}