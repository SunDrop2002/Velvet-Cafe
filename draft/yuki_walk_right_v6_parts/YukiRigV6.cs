using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.IO;
public class YukiRigV6 {
 static string dir="C:/Users/AMD/Desktop/Projects/Velvet Cafe/Velvet-Cafe/draft";
 static List<Color> palette=new List<Color>();
 static Color Match(Color c){int best=int.MaxValue;Color answer=Color.Transparent;foreach(var p in palette){int r=c.R-p.R,g=c.G-p.G,b=c.B-p.B;int d=r*r+g*g+b*b;if(d<best){best=d;answer=p;}}return answer;}
 static double Lum(Color c){return c.R*.2126+c.G*.7152+c.B*.0722;}
 static bool Hair(Color c){return c.A>0 && c.B>c.R*1.12 && c.B>c.G*1.04;}
 static Bitmap Blank(){return new Bitmap(96,96,PixelFormat.Format32bppArgb);}
 static void Enlarge(Bitmap b,string name,int size){using(var z=new Bitmap(b.Width*size,b.Height*size)){for(int y=0;y<z.Height;y++)for(int x=0;x<z.Width;x++){Color c=b.GetPixel(x/size,y/size);z.SetPixel(x,y,c.A>0?c:Color.FromArgb(54,54,60));}z.Save(dir+"/"+name,ImageFormat.Png);}}

 struct V {public double x,y;public V(double x,double y){this.x=x;this.y=y;}}
 static Bitmap Part(Bitmap source, int x0,int y0,int x1,int y1){var p=Blank();for(int y=y0;y<y1;y++)for(int x=x0;x<x1;x++)p.SetPixel(x,y,source.GetPixel(x,y));return p;}
 static void Put(Bitmap target,Bitmap part,int dx,int dy){for(int y=0;y<96;y++)for(int x=0;x<96;x++){Color c=part.GetPixel(x,y);int xx=x+dx,yy=y+dy;if(c.A>0&&xx>=0&&xx<96&&yy>=0&&yy<96)target.SetPixel(xx,yy,c);}}
 static void Rotate(Bitmap target,Bitmap part,V oldPivot,V newPivot,double angle,bool far){
  double co=Math.Cos(angle),si=Math.Sin(angle);
  for(int y=0;y<96;y++)for(int x=0;x<96;x++){
   double dx=x-newPivot.x,dy=y-newPivot.y;
   int sx=(int)Math.Round(co*dx+si*dy+oldPivot.x),sy=(int)Math.Round(-si*dx+co*dy+oldPivot.y);
   if(sx<0||sx>=96||sy<0||sy>=96)continue; Color c=part.GetPixel(sx,sy);
   if(c.A>0){if(far)c=Match(Color.FromArgb(Math.Max(0,c.R-7),Math.Max(0,c.G-7),Math.Max(0,c.B-7)));target.SetPixel(x,y,c);}
  }
 }
 static double Angle(V a,V b){return -Math.Atan2(b.x-a.x,b.y-a.y);}
 static V Knee(V hip,V ankle){
  double dx=ankle.x-hip.x,dy=ankle.y-hip.y,d=Math.Sqrt(dx*dx+dy*dy);
  double bend=Math.Sqrt(Math.Max(0,14*14-d*d/4));
  return new V((hip.x+ankle.x)/2+dy/d*bend,(hip.y+ankle.y)/2-dx/d*bend);
 }
 static void Leg(Bitmap target,Bitmap thigh,Bitmap shin,Bitmap foot,int phase,int bob,bool far){
  int[] xs={9,3,-3,-9,-5,2};int[] lifts={0,0,0,0,6,2};
  V hip=new V(48,60+bob),ankle=new V(47+xs[phase],86-lifts[phase]);
  V knee=Knee(hip,ankle);
  Rotate(target,thigh,new V(47,60),hip,Angle(hip,knee),far);
  Rotate(target,shin,new V(47,74),knee,Angle(knee,ankle),far);
  Rotate(target,foot,new V(46,86),ankle,0,far);
 }
 static void Arm(Bitmap target,Bitmap upper,Bitmap lower,int phase,int bob,bool far){
  double[] swings={-3,-1,1,3,1,-1};
  V shoulder=new V(far?52:49,33+bob),elbow=new V(shoulder.x+swings[phase]*.48,46+bob);
  V wrist=new V(shoulder.x+swings[phase]+1,59+bob);
  Rotate(target,upper,new V(46,33),shoulder,Angle(shoulder,elbow),far);
  Rotate(target,lower,new V(46,47),new V(elbow.x,elbow.y+1),Angle(elbow,wrist),far);
 }
 static void Animate(Bitmap model,Bitmap original){
  var head=Part(model,0,0,96,31);
  var torso=Part(model,0,31,96,67);
  var upper=Part(model,41,31,49,47);
  var lower=Part(model,43,47,50,62);
  // Remove the static near arm from the body. Extend adjacent existing garment pixels underneath.
  for(int y=31;y<62;y++)for(int x=39;x<50;x++){
   bool remove=y<47 ? x<49 : x<50;
   if(remove){torso.SetPixel(x,y,Color.Transparent);
    if(x>=44 && y>=33){Color c=model.GetPixel(y<47?49:50,y);if(c.A>0)torso.SetPixel(x,y,c);}
   }
  }
  // Remove static trouser pixels from the apron layer; only articulated legs supply pants.
  for(int y=59;y<67;y++)for(int x=0;x<96;x++){
   Color c=torso.GetPixel(x,y);if(c.A>0 && c.B>c.R)torso.SetPixel(x,y,Color.Transparent);
  }
  var thigh=Blank();var shin=Blank();
  // Both legs reuse one source texture; no independent frame drawings.
  // Sample a single trouser leg from the canonical idle instead of both overlapping profile legs.
  for(int y=59;y<=75;y++)for(int x=45;x<=49;x++){
   Color c=original.GetPixel(49+x-45,68+Math.Min(13,y-59));
   thigh.SetPixel(x,y,c);
  }
  for(int y=73;y<=87;y++)for(int x=45;x<=49;x++){
   Color c=original.GetPixel(49+x-45,69+Math.Min(13,y-73));
   shin.SetPixel(x,y,c);
  }
  // One compact shoe per leg, using existing shoe colors with a single sole contour.
  var foot=Blank();
  for(int y=86;y<=90;y++)for(int x=43;x<=54;x++){
   int maxX=y==86?49:(y==87?51:54);
   if(x>maxX)continue;
   Color c=model.GetPixel(Math.Min(x,53),y);
   if(c.A==0)c=original.GetPixel(51,86);
   foot.SetPixel(x,y,c);
  }
  string[] names={"head","torso","upper_arm","forearm","thigh","shin","foot"};
  Bitmap[] parts={head,torso,upper,lower,thigh,shin,foot};
  string partDir=dir+"/yuki_walk_right_v6_parts";Directory.CreateDirectory(partDir);
  for(int i=0;i<parts.Length;i++)parts[i].Save(partDir+"/"+names[i]+".png",ImageFormat.Png);
  int[] bob={0,1,0,0,1,0};
  using(var sheet=new Bitmap(576,96,PixelFormat.Format32bppArgb))
  using(var compare=new Bitmap(672,96,PixelFormat.Format32bppArgb)){
   using(var g=Graphics.FromImage(compare))g.DrawImageUnscaled(original,0,0);
   for(int f=0;f<6;f++)using(var frame=Blank()){
    Leg(frame,thigh,shin,foot,(f+3)%6,bob[f],true);
    Arm(frame,upper,lower,(f+3)%6,bob[f],true);
    Leg(frame,thigh,shin,foot,f,bob[f],false);
    LeanTorso(frame,torso,bob[f]);
    Arm(frame,upper,lower,f,bob[f],false);
    // Keep rotating sleeve pixels out of the fixed head and neck region.
    for(int y=0;y<31+bob[f];y++)for(int x=0;x<96;x++)frame.SetPixel(x,y,Color.Transparent);
    Put(frame,head,3,bob[f]);
    frame.Save(dir+"/yuki_walk_right_v6_"+(f+1)+".png",ImageFormat.Png);
    using(var g=Graphics.FromImage(sheet))g.DrawImageUnscaled(frame,96*f,0);
    using(var g=Graphics.FromImage(compare))g.DrawImageUnscaled(frame,96*(f+1),0);
   }
   sheet.Save(dir+"/yuki_walk_right_96x96_sheet_v6.png",ImageFormat.Png);
   compare.Save(dir+"/yuki_walk_right_v6_comparison.png",ImageFormat.Png);
   Enlarge(compare,"yuki_walk_right_v6_comparison_4x.png",4);
  }
  foreach(var p in parts)p.Dispose();
 }

 static void LeanTorso(Bitmap target,Bitmap torso,int bob){
  // Shift shoulders forward over the hips; preserve each source pixel and its color.
  for(int y=31;y<67;y++){int dx=(int)Math.Round(3.0*Math.Max(0,60-y)/29.0);
   for(int x=0;x<93;x++){Color c=torso.GetPixel(x,y);if(c.A>0)target.SetPixel(x+dx,y+bob,c);}
  }
 }
 public static void Main(){
 using(var original=new Bitmap(dir+"/yuki_idle_down_blink_v3_rest.png"))
 using(var model=new Bitmap(dir+"/yuki_walk_right_v4_model.png")){
  var unique=new HashSet<int>();
  for(int y=0;y<96;y++)for(int x=0;x<96;x++){Color c=original.GetPixel(x,y);if(c.A>0&&unique.Add(c.ToArgb()))palette.Add(Color.FromArgb(255,c.R,c.G,c.B));}
  // Use the canonical idle eye's lid and iris colors, with a narrow relaxed opening.
  model.SetPixel(52,20,original.GetPixel(50,21));
  model.SetPixel(53,20,original.GetPixel(51,22));
  model.SetPixel(52,21,original.GetPixel(50,23));
  model.SetPixel(53,21,original.GetPixel(51,23));
  model.SetPixel(52,22,original.GetPixel(51,24));
  model.SetPixel(53,22,original.GetPixel(50,24));
  // Reuse the original two-pixel neutral mouth instead of an upturned corner.
  model.SetPixel(55,24,original.GetPixel(45,26));
  model.SetPixel(53,25,original.GetPixel(47,27));
  model.SetPixel(54,25,original.GetPixel(48,27));
  // Taper the jaw by one pixel per row below the neutral mouth.
  model.SetPixel(54,26,Color.Transparent);
  model.SetPixel(53,27,Color.Transparent);
  model.SetPixel(53,26,original.GetPixel(44,26));
  model.SetPixel(52,27,original.GetPixel(46,29));
  model.Save(dir+"/yuki_walk_right_v6_model.png",ImageFormat.Png);
  Animate(model,original);
  using(var both=new Bitmap(192,96)){using(var g=Graphics.FromImage(both)){g.DrawImageUnscaled(original,0,0);g.DrawImageUnscaled(model,96,0);}Enlarge(both,"yuki_walk_right_v6_model_inspect.png",6);}
  Console.WriteLine("V6: tapered chin, isolated single-leg textures, static trouser remnants removed.");
 }
 }
}
