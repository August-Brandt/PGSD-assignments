// This is all done by us

package SimpleAexpr;

import java.util.Map;

public class SimpleAexpr {
    public static void main(String[] args) {
        Aexpr e1 = new Add(new CstI(17), new Var("z"));
        System.out.println(e1.toString());

        Aexpr e2 = new Sub(new Add(new CstI(7), new Var("p")), new Mul(new CstI(9), new CstI(8)));
        System.out.println(e2.toString());
        
        Aexpr e3 = new Add(new CstI(4), new CstI(0));
        System.out.println(e3.toString());
    }
}

abstract class Aexpr  {
    abstract public String toString();
    abstract public Aexpr simplify();   
    abstract public Aexpr diffeval(Var v);
    abstract public int eval(Map<String, Integer> env);
}

class CstI extends Aexpr { 
    protected final int i;
  
    public CstI(int i) { 
      this.i = i; 
    }

    public Aexpr simplify() {
        return this;
    }
  
    public String toString() {
      return ""+i;
    }

    public Aexpr diffeval(Var v) {
        return new CstI(0);
    }

    public int eval(Map<String, Integer> env) {
        return this.i;
    }
  }
  
class Var extends Aexpr { 
    protected final String name;
  
    public Var(String name) { 
      this.name = name; 
    }

    @Override
    public String toString() {
        return this.name;
    }

    @Override
    public Aexpr simplify() {
        return this;
    }

    @Override
    public Aexpr diffeval(Var v) {
        if  (this.name.equals(v.toString())) {
            return new CstI(1);
        } 
        return new CstI(0);
    } 

    public int eval(Map<String, Integer> env) {
        return env.get(this.name);
    }
}

abstract class Binop extends Aexpr{};
  
class Add extends Binop {
    protected final Aexpr e1, e2;

    public Add(Aexpr e1, Aexpr e2){
        this.e1 = e1;
        this.e2 = e2;
    }
    
    @Override
    public String toString() {
        return "(" + e1 + " + " + e2 + ")";
    }

    @Override
    public Aexpr simplify() {
        if (e2.simplify().equals(new CstI(0))) {
            return e1;
        } else if (e1.simplify().equals(e2.simplify())) {
                return new CstI(0);
        }
        return this;   
    }

    @Override
    public Aexpr diffeval(Var v) {
        return new Add(e1.diffeval(v), e2.diffeval(v));
    } 

    public int eval(Map<String, Integer> env) {
        return this.e1.eval(env) + this.e2.eval(env);
    }
}

class Sub extends Binop {
    protected final Aexpr e1, e2;

    public Sub(Aexpr e1, Aexpr e2) {
        this.e1 = e1;
        this.e2 = e2;
    } 

    public String toString() {
        return "(" + e1 + " - " + e2 + ")";
    }

    @Override
    public Aexpr simplify() {
        if (e2.simplify().equals(new CstI(0))) {
            return e1.simplify();
        }
        if (e1.simplify().equals(e2.simplify())) {
            return new CstI(0);
        }
        return this;
    }

    @Override
    public Aexpr diffeval(Var v) {
        return new Sub(e1.diffeval(v), e2.diffeval(v));
    }

    public int eval(Map<String, Integer> env) {
        return this.e1.eval(env) - this.e2.eval(env);
    }
}

class Mul extends Binop{
      
    public Mul(Aexpr e1, Aexpr e2) {
        this.e1 = e1;
        this.e2 = e2;
    } 
    
    protected final Aexpr e1, e2;

    public String toString() {
        return "(" + e1 + " * " + e2 +")";
    }

    @Override
    public Aexpr simplify() {
        if(e1.simplify().equals(0) || e2.simplify().equals(0)) {
            return new CstI(0);
        } else if (e1.simplify().equals(1)) {
            return this.e2;
        } else if (e2.simplify().equals(1)) {
            return this.e2;
        }
        return this.simplify();
        
    } 

    @Override
    public Aexpr diffeval(Var v) {
       return new Add(new Mul(e1.diffeval(v),e2),new Mul(e2.diffeval(v),e1));
    }
    
    public int eval(Map<String, Integer> env) {
        return this.e1.eval(env) * this.e1.eval(env);
    }

}