import com.sun.javaws.exceptions.InvalidArgumentException;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.function.Predicate;
import java.util.stream.Collectors;

public class _01Geometry {
    public static void main(String[] args) {
        _TwoDVertex a = new _TwoDVertex(1,1);
        _TwoDVertex b = new _TwoDVertex(2,3);
        _TwoDVertex c = new _TwoDVertex(3,1);

        _ThreeDVertex aa = new _ThreeDVertex(2,10,8);
        _ThreeDVertex bb = new _ThreeDVertex(3,5,8);

        try {

            Triangle threeAngels = new Triangle(a,b,c);
            Circle noAngels = new Circle(a, 5);
            Rektangle rektAngel = new Rektangle(b,3.14,13.37);

            SquarePyramid squareAngel = new SquarePyramid(aa, 6.9, 4.2);
            Cuboid kalufAngel = new Cuboid(bb, 4.20,6.9, 13.37);
            Sphere gasimu = new Sphere(bb, 6.9);
            Shape[] shift = new Shape[6];
            shift[0] = threeAngels;
            shift[1] = noAngels;
            shift[2] = rektAngel;
            shift[3] = squareAngel;
            shift[4] = kalufAngel;
            shift[5] = gasimu;
            for (int i = 0; i < shift.length ; i++) {
                System.out.println(shift[i].toString());
                System.out.println();
            }
            List<Shape> Shapes = Arrays.asList(shift);
            List<SpaceShape> filteredByVolume = Shapes.stream()
                    .filter(s -> s instanceof SpaceShape)
                    .map(s-> (SpaceShape) s)
                    .filter(s->s.getVolume() >400.0).collect(Collectors.toList());
            List<PlaneShape> filteredByType = Shapes.stream()
                    .filter(s -> s instanceof PlaneShape)
                    .map(s -> (PlaneShape) s)
                    .sorted((s, s1) -> (int) s.getPerimeter()).collect(Collectors.toList());
            for (Shape shape : filteredByType){
                System.out.println(shape);
            }
            System.out.println();
            for(Shape shape : filteredByVolume){
                System.out.println(shape);
            }



        } catch (InvalidArgumentException e) {
            e.printStackTrace();
        }


    }
}
